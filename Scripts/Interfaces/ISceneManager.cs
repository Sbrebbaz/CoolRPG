using static Enumerators;

public interface ISceneManager
{
	public void NavigateToGameState(GameState gameStateToNavigateTo);
	public void NavigateToScene(string scenePath);
}