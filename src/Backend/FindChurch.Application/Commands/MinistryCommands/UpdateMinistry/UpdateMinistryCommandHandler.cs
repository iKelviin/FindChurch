using FindChurch.Application.Models;
using FindChurch.Core.Entities;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Commands.MinistryCommands.UpdateMinistry;

public class UpdateMinistryCommandHandler : IRequestHandler<UpdateMinistryCommand, ResultViewModel>
{
    private readonly IMinistryRepository _repository;

    public UpdateMinistryCommandHandler(IMinistryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(UpdateMinistryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ministry = await _repository.GetByIdAsync(request.Id);
            if (ministry is null) return ResultViewModel.Error("Ministry not found");

            List<MinistryMember> members = new List<MinistryMember>();
            foreach (var member in request.Members)
            {
                MinistryMember memberUpdate = new MinistryMember(ministry.Id, member.Name,member.Role);
                members.Add(memberUpdate);
            }
            
            ministry.Update(members);
            await _repository.UpdateAsync(ministry);
            return ResultViewModel.Success();
        }
        catch (Exception e)
        {
            return ResultViewModel.Error($"Error occured: {e.Message}");
        }
    }
}