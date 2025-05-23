﻿
using AutoMapper;
using Portfolio.Business.Helpers.DTOs.Blog;
using Portfolio.Business.Helpers.DTOs.Email;
using Portfolio.Business.Helpers.DTOs.FileUpload;
using Portfolio.Business.Helpers.DTOs.Review;
using Portfolio.Core.Entities;

namespace Portfolio.Business.Helpers.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogDto, Blog>().ReverseMap();
            CreateMap<CreateBlogDto, Blog>().ReverseMap();

            CreateMap<ReviewDto, Review>().ReverseMap();
            CreateMap<CreateReviewDto, Review>().ReverseMap();

            CreateMap<ImageUrlDrto, string>().ReverseMap();
            CreateMap<CreateImageUploadDto, string>().ReverseMap(); 

            CreateMap<CreateEmailDto,string>().ReverseMap();
        }
    }
}
