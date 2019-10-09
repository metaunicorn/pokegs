﻿using RPGKit2D.Input;
using RPGKit2D.Interaction;

namespace RPGKit2D.Dialog
{
    public class DialogTrigger : Interactable
    {
        public global::RPGKit2D.Dialog.Dialog dialog;

        public override void Interact(InteractionContext ctx)
        {
            if (!ctx.dialogManager || ctx.action == ActionButton.NONE)
            {
                return;
            }

            DialogManager dm = ctx.dialogManager;

            bool shouldEndDialog = dm.InDialog()
                                   && (
                                       ((ctx.action == ActionButton.A) && !dm.HasNext())
                                       || (ctx.action == ActionButton.B)
                                   );

            if (shouldEndDialog)
            {
                dm.EndDialog();
                return;
            }

            if (ctx.action != ActionButton.A)
            {
                return;
            }

            if (!dm.InDialog())
            {
                dm.StartDialog(dialog);
                return;
            }

            dm.PrintNext();
        }
    }
}
