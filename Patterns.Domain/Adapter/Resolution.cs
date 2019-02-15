using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Domain.Adapter
{
    public class ResolutionsReport
    {
        public string ShowEDTVResolutions()
        {
            var r480p = new SpecificResolution("480p");
            var r576p = new SpecificResolution("576p");

            return $"{r480p.Display()} - {r576p.Display()}";
        }

        public string ShowHDTVResolutions()
        {
            var HD = new SpecificResolution("HD");
            var FullHD = new SpecificResolution("Full HD");

            return $"{HD.Display()} - {FullHD.Display()}";
        }
    }

    public class Resolution
    {
        protected string Description;
        protected int Width;
        protected int Height;

        public Resolution(string description)
        {
            Description = description;
        }

        public virtual string Display()
        {
            return $"{Description} {Width}x{Height}";
        }
    }

    public class SpecificResolution : Resolution
    {
        public SpecificResolution(string description) : base(description)
        {
        }

        public override string Display()
        {
            var standardResolutions = new StandardResolutions();

            return $"{Description} {standardResolutions.GetWidth(Description)}x{standardResolutions.GetHeight(Description)}";
        }
    }

    class StandardResolutions
    {
        public int GetWidth(string description)
        {
            switch (description)
            {
                case "480p":
                case "576p":
                    return 720;
                case "HD":
                    return 1280;
                case "Full HD":
                    return 1920;
                case "4K":
                    return 3840;
                case "DCI 4K":
                    return 4096;
                case "8K":
                    return 7680;
                default: return 0;
            }
        }

        public int GetHeight(string description)
        {
            switch (description)
            {
                case "480p":
                    return 480;
                case "576p":
                    return 576;
                case "HD":
                    return 720;
                case "Full HD":
                    return 1080;
                case "4K":
                case "DCI 4K":
                    return 2160;
                case "8K":
                    return 4320;
                default: return 0;
            }
        }
    }
}
