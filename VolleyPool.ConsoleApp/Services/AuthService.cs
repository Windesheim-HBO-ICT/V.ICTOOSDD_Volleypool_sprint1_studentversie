using VolleyPool.Core.Interfaces.Repositories;
using VolleyPool.Core.Models;

namespace VolleyPool.Core.Services
{
    public class AuthService
    {
        private IPlayerRepository playerRepository;
        private IParentRepository parentRepository;
        public Parent? LoggedInParent;
        public AuthService(IParentRepository parentRepository, IPlayerRepository playerRepository)
        {
            this.parentRepository = parentRepository;
            this.playerRepository = playerRepository;
        }

        public bool IsFirstLogin(Parent parent)
        {
            return parent.Password == "";
        }

        public Parent? Register(int playerMemberId, DateTime playerBirthDate, string name, string email, string phone, string password)
        {
            var player = playerRepository.Get(playerMemberId);
            if (player == null) return null;
            if (player.BirthDate != playerBirthDate) return null;

            if (password.Length < 6) return null;
            if (!password.Any(char.IsDigit)) return null;
            var parent = parentRepository.Add(new Parent { Name = name, Email = email, Phone = phone, Password = password, PlayerMemberId = playerMemberId });
            LoggedInParent = parent;

            if(player.ParentOneId == null)
            {
                player.ParentOneId = parent.Email;
            }
            else
            {
                player.ParentTwoId = parent.Email;
            }


            return parent;

            // For the sake of simplicity, this method implementation is currently of low quality.
            // To improve it:
            // - Use separate methods for each validation check: IsPlayValid, IsPasswordValid, and CreateParent.
            //   This makes the code much easier to test.
            // - Use a constructor on the Parent class instead of object initializer syntax to pass arguments.
            // - Return a Result class with meaningful success and error states.
            // - In case of errors an Exception should be used (try ... catch ...)
            //   Returning null makes it unclear what went wrong.
            // - Check if the email has been taken already. It's not part of the 'acceptatie criteria'. Analysis improvement needed!

        }

        //#student-start:UC2#
        public Parent? Login(string email, string password)
        {
            var parent = parentRepository.Get(email);
            if (parent == null) return null;
            if (parent.Password != password)
            {
                return null;
            }
            else
            {
                LoggedInParent = parent;
                return parent;
            }
        }
        //#student-end:UC2#


    }
}
