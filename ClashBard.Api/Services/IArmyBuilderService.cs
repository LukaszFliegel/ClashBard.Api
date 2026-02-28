using ClashBard.Api.DTOs;

namespace ClashBard.Api.Services;

public interface IArmyBuilderService
{
    ArmyValidationResponseDto ValidateArmy(ArmyConfigurationDto config);
    PointsBreakdownDto CalculatePoints(ArmyConfigurationDto config);
}
