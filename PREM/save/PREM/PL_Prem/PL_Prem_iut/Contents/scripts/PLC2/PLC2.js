(function (window, $) {
    var fenetreModalChargement = $('#ModaleChargement');

    // Présence d'une période de suspension dans le tableau de répartition
    presenceSuspension = false;

    // ### Initialisation des evenements ###
    $(document).ready(function () {
        $('#NumeroPratique').val('');

        var parametreIdProfessionnel = 'idProf';
        var url = window.location.href;
        var numeroProfessionnel = '';

        InactiverOnglets();
        ChangementIdentiteProfessionnel();
        InactiverPostToucheEnter()

        // Permet de vérifier si l'url contient un parametre contenant le numéro du dispensateur
        if (url.indexOf('?' + parametreIdProfessionnel + '=') != -1 || url.indexOf('&' + parametreIdProfessionnel + '=') != -1) {
            numeroProfessionnel = ObtenirParametreParNom(parametreIdProfessionnel, url);
            $('#NumeroPratique').val(numeroProfessionnel);
            $('#boutonRechercherProfessionnel').click();

            var domaine = window.location.hostname;
            // Efface le paramètre de l'url sans recharger la page
            window.history.replaceState({}, document.title, 'http://' + domaine + '/PRE/PL_Prem/ProfilProfessionnel/PLC2_Avis');

        }

        $('#NumeroPratique').focus();


    })

    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        var target = $(e.target).attr("href") // activated tab
        $('#ZoneMessage').html('').css('display', 'none');
        if (target == '#RepartitionPratique' && presenceSuspension) {
            $('#ZoneMessage').html("<span class='glyphicon glyphicon-exclamation-sign'/> " + RetourneMessageErreur('148642')).css('display', 'block');
        }
    });

    // Permet d'afficher la fenêtre de chargement
    function AfficherFenetreChargement() {
        fenetreModalChargement.modal('show');
    }

    // Permet de cacher la fenêtre de chargement
    function CacherFenetreChargement() {
        fenetreModalChargement.modal('hide');
    }

    // Permet d'empêcher la "POST" de la page lors qu'on appuis sur "ENTER"
    function InactiverPostToucheEnter() {

        $('#NumeroPratique').keydown(function (event) {
            if (event.keyCode == 13) {
                event.preventDefault();
                $('#boutonRechercherProfessionnel').click();
            }
        });

    }



    // Chargement de l'identité du professionnel
    function ChangementIdentiteProfessionnel() {

        $('#boutonRechercherProfessionnel').click(function () {
            AfficherFenetreChargement();

            $('.nav-tabs a[href="#HistoriqueEngagement"]').tab('show');

            var numeroPratique = $("#NumeroPratique").val();

            // Permet d'enlever le focus du textbox comme si l'usager aurait cliquer sur le bouton
            // et force la validation du champs
            $('#boutonRechercherProfessionnel').focus();

            if (numeroPratique.length == 6 && numeroPratique.charAt(0) == '1') {
                EffacerContenuVuePartielle();
                InactiverOnglets();

                ObtenirInformationMedecin(numeroPratique);
            }
            else {
                $('#NumeroPratique').valid();
                CacherFenetreChargement();
            }


        });
    }

    // Obtient les informations du médecin sélectionné
    function ObtenirInformationMedecin(numeroPratique) {
        if (numeroPratique.length > 0) {
            $.ajax({
                type: 'POST',
                url: controlleurPLC2.ObtenirInformationMedecin,
                data: { numeroProfessionnel: numeroPratique },
                success: function (obj) {
                    $('#informationMedecin').empty();
                    $('#MessageInformation').html('').css('display', 'none');
                    $('#ZoneMessage').html('').css('display', 'none');
                    if (obj.DateObtentionPermis != null) {
                        $('#informationMedecin').append(
                            '<p>Permis obtenu le ' + FormaterDateLong(FormatterDate(FormatterJsonDate(obj.DateObtentionPermis))) + '</p>');
                    }

                    //-PRE 084
                    var textErreur = '';
                    for (var i = 0; i < obj.MessageErreurs.length; i++) {
                        textErreur = textErreur + obj.MessageErreurs[i] + '<br />';
                    }
                    if (textErreur !== '') {
                        $('#MessageInformation').html(textErreur).css('display', 'block');
                    }

                    if (textErreur.indexOf('inexistant')==-1) {
                        ChargerVuePartielle();
                        ReactiverOnglets();
                        $('#NomPrenomProfessionnel').text(obj.NomAffichage);

                    }
                    else {
                        InactiverOnglets();
                        EffacerContenuVuePartielle();
                        CacherFenetreChargement();
                       
                        //$('#MessageInformation').html(textErreur).css('display', 'block');                        
                        $('#NomPrenomProfessionnel').text('');
                   }



                },
                error: function (err) {
                    ErreurTechnique(err, 'Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirInformationMedecin');
                }
            });
        }

    }


    // Permet de faire le chargement des vues partielle
    function ChargerVuePartielle() {

        var numeroPratique = $('#NumeroPratique').val();

        RAMQ.Web.PLC2_HistoriqueEngagement.ObtenirHistoriqueEngagement(numeroPratique);
    }

    // Permet d'effacer le contenue html des vues partielles
    function EffacerContenuVuePartielle() {

        $('#HistoriqueEngagementDiv').html('');
        $('#RepartitionPratiqueDiv').html('');
        $('#PratiqueExclusiveDiv').html('');
        $('#RegionPratiquePartielleRestreinteDiv').html('');
        $('#ReductionRemunerationDiv').html('');
    }

    // Permet d'inactiver onglets
    function InactiverOnglets() {
        $('.nav-link').attr('disabled', 'disabled').css('color', 'grey').css('cursor', 'not-allowed');
    }

    // Permet de réactiver les onglets
    function ReactiverOnglets() {
        $('.nav-link').removeAttr('disabled').removeAttr('style').removeAttr('cursor');
    }

    function InactiverOngletDRMG() {
        //$('data_id[value='PratiqueExclusive']').attr('disabled', 'disabled').css('color', 'grey').css('cursor', 'not-allowed');
        $('[data_id=PratiqueExclusive]').attr('disabled', 'disabled').css('color', 'grey').css('cursor', 'not-allowed');
    }

    // Permet d'initialiser le select2
    function InitialisationSelect2() {
        $('.select2dropdownlist').select2({
            language: 'fr',
            placeholder: '',
            allowClear: false,
            minimumResultsForSearch: -1
        });
    }

    // Permet d'ajouter le code html dans la div passer en paramètre
    function AjouterHtmlDiv(div, html) {
        div.html(html);
    }

    // Permet d'obtenir le nom du mois selon le nombre passé en paramètre
    function ObtenirMoisSelonChiffre(chiffreMois) {

        var mois = '';

        switch (chiffreMois) {
            case 1:
                mois = 'Janvier';
                break;
            case 2:
                mois = 'Fevrier';
                break;
            case 3:
                mois = 'Mars';
                break;
            case 4:
                mois = 'Avril';
                break;
            case 5:
                mois = 'Mai';
                break;
            case 6:
                mois = 'Juin';
                break;
            case 7:
                mois = 'Juillet';
                break;
            case 8:
                mois = 'Aout';
                break;
            case 9:
                mois = 'Septembre';
                break;
            case 10:
                mois = 'Octobre';
                break;
            case 11:
                mois = 'Novembre';
                break;
            case 12:
                mois = 'Decembre';
                break;
            default:
                mois = '';
                break;
        }

        return mois;

    }

    // Permet d'obtenir la valeur dans une liste de journées facturé par RSS
    function ObtenirValeurListeJourneesFacturerRSS(rss, typeJour, annee, mois) {

        $.ajax({
            type: 'POST',
            url: controlleurPLC2.ObtenirValeurListeJourneesFacturerRSS,
            data: {
                RSS: rss,
                TypeJour: typeJour,
                Annee: annee,
                Mois: mois
            },
            async: false,
            success: function (obj) {
                if (obj !== null) {
                    valeur = obj;
                }
                else {
                    valeur = '';
                }

            },
            error: function (err) {
                ErreurTechnique(err, 'Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirValeurListeJourneesFacturerRSS');
            }
        });
        return valeur;
    }

    // Permet d'obtenir les informations d'un engagement
    function ObtenirInformationEngagement(numeroSequenceEngagement) {

        $.ajax({
            type: 'POST',
            url: controlleurPLC2.ObtenirInformationEngagement,
            data: { numeroSequenceEngagement: numeroSequenceEngagement },
            async: false,
            success: function (obj) {
                engagement = obj;
            },
            error: function (err) {
                ErreurTechnique(err, 'Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirInformationEngagement');
            }
        });
        return engagement;

    }

    // Permet d'obtenir le nom du code RSS
    function ObtenirNomRSS(codeRSS) {

        $.ajax({
            type: 'POST',
            url: controlleurPLC2.ObtenirNomRSS,
            data: { codeRSS: codeRSS },
            async: false,
            success: function (retour) {
                nomRSS = retour;
            },
            error: function (err) {
                ErreurTechnique(err, 'Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirNomRSS');
            }
        });
        return nomRSS;

    }

    // Permet d'obtenir la date du jour
    function ObtenirDateDuJour() {

        var date = new Date();

        var month = date.getMonth() + 1;
        var day = date.getDate();

        var dateDuJour = date.getFullYear() + '/' +
			(('' + month).length < 2 ? '0' : '') + month + '/' +
			(('' + day).length < 2 ? '0' : '') + day;

        return dateDuJour;
    }

    function ObtenirMoisAvecAccent(mois) {
        var moisAvecAccent = '';

        switch (mois) {
            case 'Fevrier':
                moisAvecAccent = 'Février';
                break;
            case 'Aout':
                moisAvecAccent = 'Août';
                break;
            case 'Decembre':
                moisAvecAccent = 'Décembre';
                break;
            default:
                moisAvecAccent = mois;
                break;
        }

        return moisAvecAccent;
    }

    function FormaterDateLong(date) {

        var dateFormater = '';
        $.ajax({
            cache: false,
            type: 'POST',
            url: controlleurCommun.FormaterDateLong,
            data: { date: date },
            async: false,
            success: function (obj) {
                dateFormater = obj;
            },
            error: function (err) {
                ErreurTechnique(err, 'Erreur pendant un appel AJAX dans la fonction javascript FormaterDateLong');
            }
        });
        return dateFormater;
    }

    function ValiderDroitDRMG(date) {

        var estDRMG = '';
        $.ajax({
            cache: false,
            type: 'POST',
            url: controlleurPLC2.ValiderDroitDRMG,
            async: false,
            success: function (obj) {
                estDRMG = obj;
            },
            error: function (err) {
                ErreurTechnique(err, 'Erreur pendant un appel AJAX dans la fonction javascript ValiderDroitDRMG');
            }
        });
        return estDRMG;
    }
    // Permet de définir la période de mois à afficher
    function DefinirPeriodeMois(engagement, anneeSelectionner) {

        var anneeDebut = FormatterDate(FormatterJsonDate(engagement.Periode.DateDebut)).substring(0, 4);
        var moisDebut = FormatterDate(FormatterJsonDate(engagement.Periode.DateDebut)).substring(5, 7);
        var jourDebut = FormatterDate(FormatterJsonDate(engagement.Periode.DateDebut)).substring(8, 10);
        var dateDebut = new Date(anneeDebut, parseInt(moisDebut) - 1, jourDebut);
        var anneeFin;
        var moisFin;
        var jourFin;
        var dateFin;
        var moisDebutRetour;
        var moisFinRetour;

        if (engagement.Periode.DateFin == null) {
            if (parseInt(anneeSelectionner) == parseInt(anneeDebut) + 1) {
                dateFin = new Date(parseInt(anneeSelectionner) + 1, 1, 28);
                anneeFin = parseInt(anneeSelectionner) + 1;
            }
            else {
                dateFin = new Date(parseInt(anneeDebut) + 1, 1, 28);
                anneeFin = parseInt(anneeDebut) + 1;
            }

            moisFin = '12'
            jourFin = '28'
        }
        else {
            anneeFin = FormatterDate(FormatterJsonDate(engagement.Periode.DateFin)).substring(0, 4);
            moisFin = FormatterDate(FormatterJsonDate(engagement.Periode.DateFin)).substring(5, 7);
            jourFin = FormatterDate(FormatterJsonDate(engagement.Periode.DateFin)).substring(8, 10);
            dateFin = new Date(anneeFin, parseInt(moisFin) - 1, jourFin);
        }

        var nombreJours = CalculerNombreJoursPeriode(dateDebut, dateFin);

        if (nombreJours >= 365) {
            if (anneeSelectionner == anneeDebut && parseInt(moisDebut) > 2) {
                moisDebutRetour = parseInt(moisDebut) - 2;
            }
            else if (anneeSelectionner == anneeDebut) {
                moisDebutRetour = parseInt(moisDebut);
            }
            else {
                moisDebutRetour = 1;
            }

            if (anneeSelectionner == anneeFin && engagement.Periode.DateFin != null) {
                moisFinRetour = moisFin - 2;
            }
            else if (anneeSelectionner == anneeFin) {
                moisFinRetour = 12 - 2;
            }
            else {
                moisFinRetour = 12;
            }
        }
        else {
            moisDebutRetour = moisDebut;
            moisFinRetour = moisFin;

            if ((parseInt(moisDebut) == 1)) {
                moisDebutRetour = 3;
            }

            if (parseInt(moisDebutRetour) <= 2) {
                if ((parseInt(moisDebutRetour) - 2) == 0) {
                    moisDebutRetour = 12;
                }
                else if ((parseInt(moisDebutRetour) - 2) == -1) {
                    moisDebutRetour = 11;
                }
            }
            else {
                moisDebutRetour = parseInt(moisDebutRetour) - 2;
            }

            if (parseInt(moisFinRetour) <= 2) {
                if ((parseInt(moisFinRetour) - 2) == 0) {
                    moisFinRetour = 12;
                }
                else if ((parseInt(moisFinRetour) - 2) == -1) {
                    moisFinRetour = 11;
                }
            }
            else if (anneeSelectionner == anneeFin) {
                moisFinRetour = parseInt(moisFinRetour) - 2;
            }
            else {
                moisFinRetour = 12;
            }

            // Si le mois de début est plus grand que celui de fin
            if (moisDebutRetour > moisFinRetour) {
                moisDebutRetour = 1;
            }
        }


        if (anneeSelectionner < anneeDebut) {
            if (moisDebut == '02') {
                moisDebutRetour = 12;
            }
            else {
                moisDebutRetour = 11;
            }
            moisFinRetour = 12;
        }
        else if (anneeSelectionner > anneeDebut) {
            moisDebutRetour = 1;
        }

        return { MoisDebut: moisDebutRetour, MoisFin: moisFinRetour };
    }

    // Permet de calculer le nombre de jour dans une période
    function CalculerNombreJoursPeriode(dateDebut, dateFin) {
        var uneJournee = 24 * 60 * 60 * 1000;
        return Math.round(Math.abs((dateFin.getTime() - dateDebut.getTime()) / (uneJournee)));
    }

    // Permet de définir la période PREM
    function DefinirPeriodePREM(engagement, anneeSelectionner) {

        var dateDebutPREM = new Date(anneeSelectionner, 2, 1);
        var dateFinPREM;

        if (EstAnneeBissextile(parseInt(anneeSelectionner) + 1)) {
            dateFinPREM = new Date(parseInt(anneeSelectionner) + 1, 1, 29);
        }
        else {
            dateFinPREM = new Date(parseInt(anneeSelectionner) + 1, 1, 28);
        }

        var dateDebutEngagementString = FormatterDate(FormatterJsonDate(engagement.Periode.DateDebut));
        var dateFinEngagementString = null;

        var anneeDebut = dateDebutEngagementString.substring(0, 4);
        var moisDebut = dateDebutEngagementString.substring(5, 7);
        var jourDebut = dateDebutEngagementString.substring(8, 10);
        var dateDebutEngagement = new Date(anneeDebut, parseInt(moisDebut) - 1, jourDebut);

        var anneeFin;
        var moisFin;
        var jourFin;
        var dateFinEngagement;
        var dateDebutRetour;
        var dateFinRetour;


        if (engagement.Periode.DateFin !== null) {
            dateFinEngagementString = FormatterDate(FormatterJsonDate(engagement.Periode.DateFin));
            anneeFin = dateFinEngagementString.substring(0, 4);
            moisFin = dateFinEngagementString.substring(5, 7);
            jourFin = dateFinEngagementString.substring(8, 10);
            dateFinEngagement = new Date(anneeFin, parseInt(moisFin) - 1, jourFin);
        }
        else {
            // Permet de sélectionner la dernier journée du mois de février
            anneeFin = (parseInt(anneeSelectionner) + 1).toString();

            if (EstAnneeBissextile(anneeFin)) {
                dateFinEngagement = new Date(anneeFin, 1, 29);
            }
            else {
                dateFinEngagement = new Date(anneeFin, 1, 28);
            }
        }

        if (dateDebutEngagement < dateDebutPREM) {
            dateDebutRetour = dateDebutPREM;
        }
        else if (dateDebutEngagement > dateDebutPREM && anneeSelectionner == dateDebutPREM.getFullYear()) {
            dateDebutRetour = dateDebutEngagement;
        }
        else if (dateDebutEngagement > dateDebutPREM && anneeSelectionner != dateDebutEngagement.getFullYear()) {
            dateDebutRetour = dateDebutPREM;
        }
        else {
            dateDebutRetour = dateDebutEngagement;
        }


        if (dateFinEngagement >= dateFinPREM) {
            dateFinRetour = dateFinPREM;
        }
        else {
            dateFinRetour = dateFinEngagement;
        }

        return { DateDebut: dateDebutRetour, DateFin: dateFinRetour };

    }

    // Permet de savoir si l'année est bissextile
    function EstAnneeBissextile(annee) {
        return ((annee % 4 == 0) && (annee % 100 != 0)) || (annee % 400 == 0);
    }

    // Permet de formater la date sous le format YYYY-MM-DD
    function FormatDate(date) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;

        return [year, month, day].join('-');
    }

    // Permet d'obtenir la valeur du paramètre avec le nom passé en paramètre
    function ObtenirParametreParNom(nom, url) {
        if (!url) url = window.location.href;
        nom = nom.replace(/[\[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + nom + '(=([^&#]*)|&|#|$)'),
            resultats = regex.exec(url);
        if (!resultats) return null;
        if (!resultats[2]) return '';
        return decodeURIComponent(resultats[2].replace(/\+/g, ' '));
    }


    // ### Interfaces ###
    if ('undefined' == typeof (window.RAMQ))
        window.RAMQ = new Object();

    if ('undefined' == typeof (window.RAMQ.Web))
        window.RAMQ.Web = new Object();

    if ('undefined' == typeof (window.RAMQ.Web.PLC2))
        window.RAMQ.Web.PLC2 = {
            'AfficherFenetreChargement': AfficherFenetreChargement,
            'CacherFenetreChargement': CacherFenetreChargement,
            'InitialisationSelect2': InitialisationSelect2,
            'AjouterHtmlDiv': AjouterHtmlDiv,
            'ObtenirMoisSelonChiffre': ObtenirMoisSelonChiffre,
            'ObtenirValeurListeJourneesFacturerRSS': ObtenirValeurListeJourneesFacturerRSS,
            'ObtenirInformationEngagement': ObtenirInformationEngagement,
            'ObtenirNomRSS': ObtenirNomRSS,
            'ObtenirDateDuJour': ObtenirDateDuJour,
            'ObtenirMoisAvecAccent': ObtenirMoisAvecAccent,
            'InactiverOngletDRMG': InactiverOngletDRMG,
            'ValiderDroitDRMG': ValiderDroitDRMG,
            'InactiverOnglets': InactiverOnglets,
            'DefinirPeriodeMois': DefinirPeriodeMois,
            'DefinirPeriodePREM': DefinirPeriodePREM,
            'FormatDate': FormatDate
        };

})(window, $);
