using AutoMapper;
using MediatR;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Apartment.Insert
{
    public class InsertApartmentCommandHandler : IRequestHandler<InsertApartmentCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InsertApartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseItem> Handle(InsertApartmentCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();

            var apartment = _mapper.Map<Data.Entity.Apartment>(request);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IApartmentRepository>().Add(apartment);

            if (await _unitOfWork.SaveChangesAsync()<1)
            {
                _unitOfWork.Rollback();
                return response.Error(MessageCodesEnum.Error);
            }
            _unitOfWork.Commit();
            return response.Ok();
        }
    }
}
