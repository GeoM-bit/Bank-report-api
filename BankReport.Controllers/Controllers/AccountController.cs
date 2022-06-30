using BankReport.DatabaseModels;
using BankReport.Logic.DtoModels;
using BankReport.Logic.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankReport.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private AccountRepository repository;
        public AccountController(AccountRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IQueryable<AccountDto> Get()
        {
            return repository.GetAll();
        }
        [HttpGet("{id}")]
        public AccountDto GetById(Guid id)
        {
            return repository.GetById(id);
        }
        
        [HttpPost]
        public void Post(Account account)
        {
            repository.Post(account);
            repository.Save();
        }
        
        [HttpPut("{id}")]
        public void Put(Guid id)
        {
            repository.Put(id);
            repository.Save();
        }
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            repository.Delete(id);
            repository.Save();
        }
      
    }

}
