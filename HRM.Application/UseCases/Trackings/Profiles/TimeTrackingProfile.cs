using AutoMapper;
using HRM.Application.UseCases.Trackings.Commands;
using HRM.Application.UseCases.Trackings.DTOs;
using HRM.Domain.Entities.Trackings;

namespace HRM.Application.UseCases.Trackings.Profiles;

public class TimeTrackingProfile : Profile
{
    public TimeTrackingProfile()
    {
        CreateMap<TimeTracking, TimeTrackingDto>();

        CreateMap<UpdateTrackCommand, TimeTracking>();
    }
}