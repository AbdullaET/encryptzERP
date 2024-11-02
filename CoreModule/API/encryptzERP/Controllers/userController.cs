using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using encrypzERP.BL.dbContexts;
using encrypzERP.BL.Models;
using encrypzERP.BL.Services.users;

namespace encryptzERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly Iusers _userService;

        public userController(Iusers userService)
        {
            _userService = userService;
        }

        // GET: api/accounts
        [HttpGet]
        public async Task<ActionResult<List<mUsers>>> GetUsers()
        {
            var accounts = await _userService.GetUsersAsync();
            return Ok(accounts);
        }

        //// GET: api/accounts/{id}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<mUsers>> GetUserById(int id)
        //{
        //    var account = await _userService.GetUserByIdAsync(id);
        //    if (account == null)
        //        return NotFound();

        //    return Ok(account);
        //}

        //// POST: api/accounts
        //[HttpPost]
        //public async Task<ActionResult> CreateUser([FromBody] ChartOfAccounts newAccount)
        //{
        //    await _accountService.CreateAccountAsync(newAccount);
        //    return CreatedAtAction(nameof(GetAccountById), new { id = newAccount.AccountID }, newAccount);
        //}

        //// PUT: api/accounts/{id}
        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateAccount(int id, [FromBody] ChartOfAccounts updatedAccount)
        //{
        //    if (id != updatedAccount.AccountID)
        //        return BadRequest("Account ID mismatch");

        //    var existingAccount = await _accountService.GetAccountByIdAsync(id);
        //    if (existingAccount == null)
        //        return NotFound();

        //    await _accountService.UpdateAccountAsync(updatedAccount);
        //    return NoContent();
        //}

        //// DELETE: api/accounts/{id}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteAccount(int id)
        //{
        //    var account = await _accountService.GetAccountByIdAsync(id);
        //    if (account == null)
        //        return NotFound();

        //    await _accountService.DeleteAccountAsync(id);
        //    return NoContent();
        //}

    }
}
