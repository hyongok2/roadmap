﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDictionary.TriggerAction
{
    public class FadeTriggerAction : TriggerAction<VisualElement>
    {
        public int StartsFrom { get; set; }

        protected override void Invoke(VisualElement sender)
        {
            sender.Animate("FadeTriggerAction", new Animation((d) =>
            {
                var val = StartsFrom == 1 ? d : 1 - d;
                sender.BackgroundColor = Color.FromRgb(1, val, 1);
            }),
            length: 1000, // milliseconds
            easing: Easing.Linear);
        }
    }
}
