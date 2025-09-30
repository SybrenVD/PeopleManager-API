using Microsoft.EntityFrameworkCore;
using PeopleManageer.Dto.Requests;
using PeopleManageer.Dto.Results;
using PeopleManager.Model;
using PeopleManager.Repository;

namespace PeopleManager.Services
{
    public class FunctionService
    {
        private readonly PeopleManagerDbContext _dbContext;

        public FunctionService(PeopleManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FunctionResult>> Find()
        {
            var functionsTask = await _dbContext.Functions
                .Select(f => new FunctionResult
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    NumberOfPeople = f.People.Count
                }).ToListAsync();
            return functionsTask;
        }

        // opgesplits voor duidelijkheid

        //public Task<List<FunctionResult>> Find()
        //{
        //    var query = _dbContext.Functions
        //        .Select(f => new FunctionResult
        //        {
        //            Id = f.Id,
        //            Name = f.Name,
        //            Description = f.Description,
        //            NumberOfPeople = f.People.Count
        //        });

        //    var functions = query.ToListAsync();
        //    return functions;
        //}

        public async Task<FunctionResult?> Get(int id)
        {
            var function = await _dbContext.Functions
                .Select(f => new FunctionResult
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    NumberOfPeople = f.People.Count
                }).FirstOrDefaultAsync(f => f.Id == id);
            return function;
        }

        public async Task<FunctionResult?> Create(FunctionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return null;
            }

            var function = new Function
            {
                Name = request.Name,
                Description = request.Description
            };

            _dbContext.Functions.Add(function);

            await _dbContext.SaveChangesAsync();

            return await Get(function.Id);
        }

        public async Task<FunctionResult?> Update(int id, FunctionRequest request)
        {
            var function = await _dbContext.Functions
                .FirstOrDefaultAsync(f => f.Id == id);

            if (function == null)
            {
                return null;
            }

            await _dbContext.SaveChangesAsync();

            return await Get(function.Id);
        }

        public async Task Delete(int id)
        {
            var function = await _dbContext.Functions
                .FirstOrDefaultAsync(f => f.Id == id);

            if (function is null)
            {
                return;
            }
            //var function = new Function { Id = id, Name = string.Empty };
            //_dbContext.Functions.Attach(function);

            _dbContext.Functions.Remove(function);

            await _dbContext.SaveChangesAsync();
        }
    }
}
