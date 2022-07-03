using AutoMapper;
using BankReport.DatabaseModels;
using BankReport.Logic.DtoModels;
using BankReport.Logic.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankReport.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IRepositoryTransaction<Transaction, Guid, List<TransactionReport>> _repository;

        private readonly IMapper _mapper;
        public TransactionController(IRepositoryTransaction<Transaction, Guid, List<TransactionReport>> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<TransactionDto>> Get()
        {
            var result = await _repository.GetAll();
            var results = _mapper.Map<List<TransactionDto>>(result);

            return results;
        }
        [HttpGet("{id}")]
        public async Task<TransactionDto> GetById([FromRoute] Guid id)
        {
            var result = await _repository.GetById(id);
            var results = _mapper.Map<TransactionDto>(result);

            return results;
        }

        [HttpPost]
        public async Task Post(Transaction transaction)
        {
            await _repository.Post(transaction);
        }

        [HttpPut("{id}")]
        public async Task Put(Guid id, Transaction transaction)
        {
            await _repository.Put(id, transaction);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }
        
        [HttpGet("report/{id}")]

        public async Task<Array> Report([FromRoute]Guid id)
        {
            var result = await _repository.Report(id);
            var results = _mapper.Map<List<ReportDto>>(result).ToArray();
            return results;
        }
        
    }
}
