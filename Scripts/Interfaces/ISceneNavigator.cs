using static Enumerators;

public interface ISceneNavigator
{
	public void NavigateToGameState(GameState gameStateToNavigateTo);
	public void NavigateToScene(string scenePath);
}