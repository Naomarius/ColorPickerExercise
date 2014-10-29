using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcApplication1.Models;

namespace MvcApplication1.DAL
{
    public class ColorInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ColorPickerContext>
    {
        protected override void Seed(ColorPickerContext context)
        {
            var colors = new List<Color>
            {
            new Color{ColorName="Red"},
            new Color{ColorName="Blue"},
            new Color{ColorName="Green"},
            new Color{ColorName="Violet"},
            new Color{ColorName="Indigo"},
            new Color{ColorName="Orange"},
            new Color{ColorName="Yellow"}
            };
            colors.ForEach(s => context.Colors.Add(s));
            context.SaveChanges();
        }
    }
}