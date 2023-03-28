using POC.GoldenRaspberryAwards.API.Domain.Entities;

namespace POC.GoldenRaspberryAwards.API.Application;

public interface IAwardService
{
    Task<AwardIntervals> GetAwardIntervals();
}
