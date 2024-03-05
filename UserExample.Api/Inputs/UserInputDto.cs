namespace UserExample.Api.Inputs
{
    public record UserCreationData(NameVo name, ContactInformationVo contactInformation, AddressVo address, string userName, string roleName);
}
