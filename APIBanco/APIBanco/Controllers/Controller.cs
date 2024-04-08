using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhaPrimeiraAPI.Controllers
{
    [ApiController]
    [Route("api/bank")]
    public class BankController : ControllerBase
    {
        private static List<User> users = new List<User>();

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        [HttpPost("users")]
        public IActionResult CreateUser(User user)
        {
            user.UserId = Guid.NewGuid().ToString(); // Gerar um ID único para o usuário
            users.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
        }

        [HttpGet("users/{userId}")]
        public IActionResult GetUserById(string userId)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(user);
        }

        [HttpPost("users/{userId}/accounts")]
        public IActionResult CreateAccount(string userId)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var account = new Account
            {
                AccountId = Guid.NewGuid().ToString(), // Gerar um ID único para a conta
                Balance = 0 // Inicializa o saldo da conta como zero
            };

            user.Accounts.Add(account);
            return CreatedAtAction(nameof(GetAccountById), new { accountId = account.AccountId }, account);
        }

        [HttpGet("users/{userId}/accounts")]
        public IActionResult GetAccountsByUser(string userId)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(user.Accounts);
        }

        [HttpGet("accounts/{accountId}")]
        public IActionResult GetAccountById(string accountId)
        {
            var account = users.SelectMany(u => u.Accounts).FirstOrDefault(a => a.AccountId == accountId);
            if (account == null)
            {
                return NotFound("Conta não encontrada.");
            }
            return Ok(account);
        }

        [HttpPost("accounts/{accountId}/deposit")]
        public IActionResult Deposit(string accountId, [FromBody] decimal amount)
        {
            var account = users.SelectMany(u => u.Accounts).FirstOrDefault(a => a.AccountId == accountId);
            if (account == null)
            {
                return NotFound("Conta não encontrada.");
            }

            account.Balance += amount;
            return Ok(account);
        }

        [HttpPost("accounts/{accountId}/withdraw")]
        public IActionResult Withdraw(string accountId, [FromBody] decimal amount)
        {
            var account = users.SelectMany(u => u.Accounts).FirstOrDefault(a => a.AccountId == accountId);
            if (account == null)
            {
                return NotFound("Conta não encontrada.");
            }

            if (account.Balance < amount)
            {
                return BadRequest("Saldo insuficiente para saque.");
            }

            account.Balance -= amount;
            return Ok(account);
        }
    }
}
