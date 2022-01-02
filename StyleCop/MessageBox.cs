using System;
using System.Threading.Tasks;

namespace StyleCop
{
    public class MessageBox
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<Ожидание>")]
        public Action ActionClose;
        public State St;
#pragma warning disable CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
        public async void Open()
#pragma warning restore CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
        {
            Console.WriteLine("Окно открыто");
            Task.Delay(300).Wait();
            Console.WriteLine("Окно закрыто");

            var rn = new Random();
            var res = rn.Next(1, 3);

            if (res == 1)
            {
                St = State.Ok;
                ActionClose += Open;

                ActionClose?.Invoke();
            }
            else
            {
                St = State.Cancel;
                ActionClose += Open;

                ActionClose?.Invoke();
            }
        }
    }
}
