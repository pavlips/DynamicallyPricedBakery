namespace DynamicBakery.Screens.DashboardUserControls
{
    public class NavigationControls
    {
        private List<UserControl> controls = new List<UserControl>();
        private Panel panel;

        public NavigationControls(List<UserControl> controls, Panel panel)
        {
            this.controls = controls;
            this.panel = panel;
            AddUserControls();
        }

        private void AddUserControls() 
        {
            for (int i = 0; i < controls.Count; i++)
            {
                controls[i].Dock = DockStyle.Fill;
                panel.Controls.Add(controls[i]);
            }
        }

        public void DisplayControl(int index) // display the control at the index
        {
            if (index < controls.Count)
            {
                controls[index].BringToFront();
            }
        }
    }
}
