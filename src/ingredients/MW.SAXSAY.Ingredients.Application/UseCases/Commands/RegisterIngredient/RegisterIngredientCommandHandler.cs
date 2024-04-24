using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Ingredients.Domain.Entities;
using MW.SAXSAY.Ingredients.Domain.Interfaces;
using MW.SAXSAY.Ingredients.Domain.ValueObjects;

namespace MW.SAXSAY.Ingredients.Application.UseCases.Commands;

public class RegisterIngredientCommandHandler
    : IRequestHandler<RegisterIngredientCommand, BaseResponse<IngredientId>>
{
    #region Properties & Variables
    private readonly IUnitOfWorkIngredient _unitOfWorkIngredient;
    #endregion

    #region Constructor
    public RegisterIngredientCommandHandler(IUnitOfWorkIngredient unitOfWorkIngredient)
    {
        _unitOfWorkIngredient = unitOfWorkIngredient;
    }
    #endregion // Constructor

    #region Methods
    public async Task<BaseResponse<IngredientId>> Handle(
        RegisterIngredientCommand request,
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IngredientId>();

        // prepare ingredient
        Ingredient.IngredientBuilder ingredientBuilder = new();
        ingredientBuilder.WithDescription(request.Description);
        ingredientBuilder.WithStatusActive(true);
        Ingredient ingredient = ingredientBuilder.Build();

        try
        {
            IngredientId? ingredientId =
                await _unitOfWorkIngredient
                    .IngredientRepository
                    .RegisterAsync(ingredient, cancellationToken);

            if (ingredientId is not null)
            {
                response.IsSuccess = true;
                response.Data = ingredientId;
                response.Message = "Success!";
            }

            await _unitOfWorkIngredient.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            throw;
        }

        return response;
    }
    #endregion
}