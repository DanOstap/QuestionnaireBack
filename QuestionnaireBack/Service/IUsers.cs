using QuestionnaireBack.Models;

namespace QuestionnaireBack.Service
{
    public interface IUsers
    {
        public Task<Users> Create(Users dto);
        public Task<Users?> FindOneByName(string email);
        public Task<List<Users>?> FindAll();
        public Task<Users?> Remove(string name);
    }
}
