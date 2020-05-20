using System;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        public static IPostInformationService _postInformationService;
        public static IUserInformationService _userInformationService;
        public static IDisplayInformationService _displayInformationService;
       public static async Task Main(string[] args)
        {
            _userInformationService = new UserInformationService();
            _postInformationService = new PostInformationService();
            _displayInformationService = new DisplayInformationService(_userInformationService, _postInformationService);
            System.Console.WriteLine("Hello World!");
            // var userIdInline = args[0];
            var userIdInline = "1";
            try
            {
                int userId = int.Parse(userIdInline);
                await Handle(userId);
            }
            catch
            {
                System.Console.Error.WriteLine("You should enter a valid userId");
            }           
        }

        private static async Task Handle(int userId)
        {
            var res = await _displayInformationService.GetInformation(userId);
            if(res != null)
            {

                System.Console.WriteLine($"Id Post \t Post Title \t UserName");
                foreach(var elem in res)
                {
                    System.Console.WriteLine($"{elem.Id} \t {elem.JobTitle} \t  {elem.Name}");
                }
            }
        }
    }
}
