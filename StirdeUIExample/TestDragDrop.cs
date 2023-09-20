using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Input;
using Stride.UI;
using Stride.UI.Panels;
using System.Linq;

namespace StirdeUIExample;
public class TestDragDrop : SyncScript
{
	public UIComponent UIComponent { get; set; }

	private UIPage _page;
	private Canvas _canvas;

	private UIElement _selectedElement;

	public override void Start()
	{
		_page = UIComponent.Page;
		_canvas = _page.RootElement.FindVisualChildOfType<Canvas>();
	}
	public override void Update()
	{
		Select();
		Drag();
		Drop();
	}

	private void Select()
	{
		if (Input.Mouse.IsButtonPressed(MouseButton.Left))
		{
			var elementsSelected = _canvas.Children.Where(x => x.MouseOverState == MouseOverState.MouseOverElement);
			_selectedElement = elementsSelected.FirstOrDefault();
		}
	}

	private void Drag()
	{
		if(_selectedElement != null && Input.Mouse.IsButtonDown(MouseButton.Left))
		{
			var mousePos = Input.AbsoluteMousePosition;
			DebugText.Print("Mouse is held " + mousePos, new Int2(50, 50));
			_selectedElement.SetCanvasAbsolutePosition(new Vector3(mousePos.X, mousePos.Y , _selectedElement.Depth));
		}
	}

	private void Drop()
	{
		if (Input.Mouse.IsButtonReleased(MouseButton.Left))
		{
			_selectedElement = null;
		}
	}
}
