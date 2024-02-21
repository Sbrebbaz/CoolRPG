﻿public interface IDialogManager
{
    public void ShowDialog(DialogBase dialog);
    public void ShowDialog(DialogLineBase dialogLineData);
	public void CloseDialog();
	public void EndDialog();
}