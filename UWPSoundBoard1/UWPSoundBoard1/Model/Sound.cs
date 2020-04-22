using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSoundBoard1.Model
{
    public enum SoundCategory
    {
        Animals,
        Cartoons,
        Warnings,
        Taunts
    }
    public class Sound
    {
        public String name { get; set; }

        public SoundCategory category { get; set; }

        public string audioFile { get; set; }

        public string imageFile { get; set; }

       
        public Sound(string Name, SoundCategory Category)
        {
            name = Name;
            category = Category;
            audioFile = $"/Assets/Audio/{Category}/{Name}.wav";
            imageFile = $"/Assets/Images/{Category}/{Name}.png";
        }
    }
}
    
   
