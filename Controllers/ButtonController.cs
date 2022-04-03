using ASPCoreFirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstApp.Controllers
{
    public class ButtonController : Controller
    {
        static List<ButtonModel> buttons = new List<ButtonModel>();
        Random random = new Random();
        const int GRID_SIZE = 25;

        public IActionResult Index()
        {

            if (buttons.Count < GRID_SIZE)
            {
                for (int i = 0; i < GRID_SIZE; i++)
                {
                    buttons.Add(new ButtonModel { Id = i, ButtonState = random.Next(4) });
                }
            }
            return View("Index", buttons);
        }

        public IActionResult HandleButtonClick(string buttonNumber)
        {
            // convert from string to int.
            int bN = int.Parse(buttonNumber);
            // add one to the button state.If greater than 4, reset to e.
            buttons.ElementAt(bN).ButtonState = (buttons.ElementAt(bN).ButtonState + 1) % 4;
            // re-display the buttons
            return View("Index", buttons);
        }



        public IActionResult ShowOneButton(int buttonNumber)
        {
            // add one to the button state. If greater than 4, reset to 0.
            buttons.ElementAt(buttonNumber).ButtonState = (buttons.ElementAt(buttonNumber).ButtonState + 1) % 4;
            // re-display the button that was clicked
            return PartialView(buttons.ElementAt(buttonNumber));
        }

        public IActionResult RightclickShowOneButton(int buttonNumber)
        { 
           // on right click always reset to e.
           buttons.ElementAt(buttonNumber).ButtonState = 0;
           // re-display the button that was clicked
            return PartialView("ShowOnebutton", buttons.ElementAt(buttonNumber));
        }
    }
}
