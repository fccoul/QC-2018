using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo;

public interface ITraitEveneAutreSys
{
    IAjusterAvisConformite AjusterAvisConformite { get; set; }
    ITraiterAdmissProf TraiterAdmissProf { get; set; }

    ParamSortiAjusterAvisConformiteMedResidents AjusterAvisConformiteMedResidents(ParamEntreAjusterAvisConformiteMedResidents intrant);
    ParamSortiTraiterAdmissProf TraiterAdmissibiliteDuProfessionnel(ParamEntreTraiterAdmissProf intrant);
}