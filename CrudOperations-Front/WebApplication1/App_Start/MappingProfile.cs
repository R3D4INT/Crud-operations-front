using System.Resources;
using AutoMapper;
using WebApplication1.Models.Localization;
using WebApplication1.Models.Localization.Home;
using WebApplication1.Models.Localization.User;

namespace WebApplication1.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ResourceSet, UserViewModel>()
                .ForMember(dest => dest.UserOperationsTitle, opt => opt.MapFrom(src => src.GetString("UserOperations_Title")))
                .ForMember(dest => dest.Add, opt => opt.MapFrom(src => src.GetString("Add")))
                .ForMember(dest => dest.Edit, opt => opt.MapFrom(src => src.GetString("Edit")))
                .ForMember(dest => dest.Delete, opt => opt.MapFrom(src => src.GetString("Delete")));
            CreateMap<ResourceSet, EditViewModel>()
                .ForMember(dest => dest.EditOperation, opt => opt.MapFrom(src => src.GetString("EditOperation")))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.GetString("User")))
                .ForMember(dest => dest.BackToList, opt => opt.MapFrom(src => src.GetString("BackToList")))
                .ForMember(dest => dest.SuccessfulResult, opt => opt.MapFrom(src => src.GetString("SuccessfulResult")))
                .ForMember(dest => dest.ValidationError, opt => opt.MapFrom(src => src.GetString("ValidationError")))
                .ForMember(dest => dest.Error, opt => opt.MapFrom(src => src.GetString("Error")))
                .ForMember(dest => dest.ErrorOccured, opt => opt.MapFrom(src => src.GetString("ErrorOccured")));
            CreateMap<ResourceSet, DeleteViewModel>()
                .ForMember(dest => dest.DeleteOperation, opt => opt.MapFrom(src => src.GetString("DeleteOperation")))
                .ForMember(dest => dest.Confirmation, opt => opt.MapFrom(src => src.GetString("Confirmation")))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.GetString("User")))
                .ForMember(dest => dest.BackToList, opt => opt.MapFrom(src => src.GetString("BackToList")))
                .ForMember(dest => dest.SuccessfulDeletion, opt => opt.MapFrom(src => src.GetString("SuccessfulDeletion")))
                .ForMember(dest => dest.ErrorOccured, opt => opt.MapFrom(src => src.GetString("ErrorOccured")));
            CreateMap<ResourceSet, AddViewModel>()
                .ForMember(dest => dest.AddOperation, opt => opt.MapFrom(src => src.GetString("AddOperation")))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.GetString("User")))
                .ForMember(dest => dest.Back, opt => opt.MapFrom(src => src.GetString("Back")))
                .ForMember(dest => dest.SuccessfulAdding, opt => opt.MapFrom(src => src.GetString("SuccessfulAdding")))
                .ForMember(dest => dest.Create, opt => opt.MapFrom(src => src.GetString("Create")))
                .ForMember(dest => dest.ErrorOccured, opt => opt.MapFrom(src => src.GetString("ErrorOccured")));
            CreateMap<ResourceSet, IndexViewModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.GetString("Title")))
                .ForMember(dest => dest.IndexTitle, opt => opt.MapFrom(src => src.GetString("IndexTitle")))
                .ForMember(dest => dest.IndexWelcome, opt => opt.MapFrom(src => src.GetString("IndexWelcome")))
                .ForMember(dest => dest.IndexLearnMore, opt => opt.MapFrom(src => src.GetString("IndexLearnMore")))
                .ForMember(dest => dest.IndexFirstSectionTitle, opt => opt.MapFrom(src => src.GetString("IndexFirstSectionTitle")))
                .ForMember(dest => dest.IndexFirstSectionMessage, opt => opt.MapFrom(src => src.GetString("IndexFirstSectionMessage")))
                .ForMember(dest => dest.IndexSecondSectionTitle, opt => opt.MapFrom(src => src.GetString("IndexSecondSectionTitle")))
                .ForMember(dest => dest.IndexSecondSectionMessage, opt => opt.MapFrom(src => src.GetString("IndexSecondSectionMessage")))
                .ForMember(dest => dest.IndexThirdSectionTitle, opt => opt.MapFrom(src => src.GetString("IndexThirdSectionTitle")))
                .ForMember(dest => dest.IndexThirdSectionMessage, opt => opt.MapFrom(src => src.GetString("IndexThirdSectionMessage")));
            CreateMap<ResourceSet, ContactViewModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.GetString("Title")))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.GetString("Message")))
                .ForMember(dest => dest.Support, opt => opt.MapFrom(src => src.GetString("Support")))
                .ForMember(dest => dest.Marketing, opt => opt.MapFrom(src => src.GetString("Marketing")));
            CreateMap<ResourceSet, AboutViewModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.GetString("Title")))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.GetString("Message")))
                .ForMember(dest => dest.Introduction, opt => opt.MapFrom(src => src.GetString("Introduction")));
        }
    }
}