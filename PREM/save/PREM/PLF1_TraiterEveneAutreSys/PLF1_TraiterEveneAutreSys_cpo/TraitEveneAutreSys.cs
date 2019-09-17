using System;
using System.Collections.Generic;
using System.Linq;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo;
using RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.Message;

/// <summary>
/// 
/// </summary>
public class TraitEveneAutreSys : ITraitEveneAutreSys
{

    IAjusterAvisConformite _ajusterAvisConformite;
    ITraiterAdmissProf _traiterAdmissProf;

    /// <summary>
    /// Dépendance CPO AjusterAvisConformite
    /// </summary>
    public IAjusterAvisConformite AjusterAvisConformite
    {
        get
        {
            return _ajusterAvisConformite;
        }

        set
        {
            _ajusterAvisConformite = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public ITraiterAdmissProf TraiterAdmissProf
    {
        get
        {
            return _traiterAdmissProf;
        }

        set
        {
            _traiterAdmissProf = value;
        }
    }

    /// <summary>
    /// Constructeur de la cpo
    /// </summary>
    /// <param name="ajusterAvisConformite"></param>
    public TraitEveneAutreSys(IAjusterAvisConformite ajusterAvisConformite, ITraiterAdmissProf traiterAdmissProf)
    {
        if (ajusterAvisConformite == null)
        {
            throw new ArgumentNullException($"Le paramètre : {nameof(ajusterAvisConformite)} ne peut être null.");
        }

        if (traiterAdmissProf == null)
        {
            throw new ArgumentNullException($"Le paramètre : {nameof(traiterAdmissProf)} ne peut être null.");
        }

        _ajusterAvisConformite = ajusterAvisConformite;
        _traiterAdmissProf = traiterAdmissProf;
    }

    /// <summary>
    /// Cette étape considère les modifications à un dispensateur pour ajuster les avis de conformité des médecins résidents (classe « 5 ») qui passent à la classe « 1 ».
    /// L'utilisation des courtes méthodes de vérification a été faite pour aider les tests unitaires.
    /// </summary>
    /// <param name="intrant">Paramètre d'entré</param>
    /// <returns>Classe vide héritant de ParamSorti</returns>
    /// <remarks></remarks>
    public ParamSortiAjusterAvisConformiteMedResidents AjusterAvisConformiteMedResidents(ParamEntreAjusterAvisConformiteMedResidents intrant)
    {
        ParamSortiAjusterAvisConformiteMedResidents sortant;
        List<long> listeNumNoSeqMedResidents;
        List<long> listeIdAvisACorriger;

        var messagesErreurs = new List<MsgTrait>();

        try
        {

            sortant = AjusterAvisConformite.VerifierParametresEntree(intrant);
            MessageTraitement.ValiderMessageTraitement(sortant);

            //On termine le traitement si la classe n'est pas à traiter
            if (!AjusterAvisConformite.VerifierSiClasseUne(intrant.PvcClaDisp))
            {
                return sortant;
            }

            //On vérifie ensuite si le dispensateur était un résident, si oui on doit retrouver une occurence avec la classe 5 depuis EPZ3
            listeNumNoSeqMedResidents = AjusterAvisConformite.ObtenirDispensateursAssociesDeClasseCinq(intrant.IndNoSeq);

            //S'il n'y a aucune occurence de trouvée, on termine le traitement avec succès
            if (!AjusterAvisConformite.VerifierSiMedResidentPresent(listeNumNoSeqMedResidents))
            {
                return sortant;
            }

            //On regarde maintenant les avis de conformité à corriger pour chaque dispensateur de classe 5 trouvé
            listeIdAvisACorriger = AjusterAvisConformite.ObtenirIDAvisConformiteAModifier(listeNumNoSeqMedResidents);

            //Finir le traitement si aucun avis à traiter n'a été trouvé
            if (!AjusterAvisConformite.VerifierSiAvisATraiter(listeIdAvisACorriger))
            {
                return sortant;
            }

            //Sinon, faire la modification sur les avis trouvés
            messagesErreurs=AjusterAvisConformite.ModifierAvisConformiteACorriger(intrant.DisNoSeq, listeIdAvisACorriger);
            if (messagesErreurs.Count > 0)
            {
                sortant.InfoMsgTrait = messagesErreurs;
            }

        }
        catch (Exception)
        {
            throw;
        }

        return sortant;
    }


    /// <summary>
    /// Ferme les avis de conformité et dérogations d'un professionnel si nécessaire
    /// </summary>
    /// <param name="intrant">Paramètre d'entrée</param>
    /// <returns>Une liste des avis de conformité avec leurs statuts</returns>
    /// <remarks></remarks>
    public ParamSortiTraiterAdmissProf TraiterAdmissibiliteDuProfessionnel(ParamEntreTraiterAdmissProf intrant)
    {
        ParamSortiTraiterAdmissProf sortant = new ParamSortiTraiterAdmissProf();

        try
        {
            if (TraiterAdmissProf.EstUnEvenementDeSuppression(intrant.MessageEvenement))
            {
                sortant = TraiterAdmissProf.TraiterEvenementSuppression(intrant);
            }
            else if (TraiterAdmissProf.EstUnEvenementDAjout(intrant.MessageEvenement) || TraiterAdmissProf.EstUnEvenementDeModification(intrant.MessageEvenement))
            {
                sortant = TraiterAdmissProf.TraiterEvenementAjoutModification(intrant);
            }
        }
        catch (Exception)
        {
            throw;
        }

        return sortant;
    }



}