﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ForkliftQuiz.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ForkliftQuizDbContext _context;

        public UserRepository(ForkliftQuizDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            if (string.IsNullOrEmpty(user.Role)) 
            {
                user.Role = "User"; 
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
