using AutoMapper;
using BankReport.DatabaseModels;
using BankReport.Logic.DtoModels;
using BankReport.Logic.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankReport.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IRepository<Account, Guid> _repository;

        private readonly IMapper _mapper;
        public AccountController(IRepository<Account, Guid> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<AccountDto>> Get()
        {
            var result = await _repository.GetAll();
            var results = _mapper.Map<List<AccountDto>>(result);

            return results;
        }
        [HttpGet("{id}")]
        public async Task<AccountDto> GetById([FromRoute] Guid id)
        {
            var result = await _repository.GetById(id);
            var results = _mapper.Map<AccountDto>(result);

            return results;
        }
        
        [HttpPost]
        public async Task Post(Account account)
        {
            await _repository.Post(account);
        }
        
        [HttpPut("{id}")]
        public async Task Put(Guid id, Account account)
        {
            await _repository.Put(id, account);   
        }
        
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }
      
    }

}
