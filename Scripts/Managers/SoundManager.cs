using Godot;
using Godot.Collections;
using System;
using System.IO;
using static Enumerators;

public partial class SoundManager : Node, ISoundManager
{
	private const string basePath = "res://Assets/Sound effects/";
	private const string oggExtension = ".ogg";
	private const string wavExtension = ".wav";

	private Dictionary<SoundEffects, AudioStream> _sounds = new Dictionary<SoundEffects, AudioStream>();

	private AudioStreamPlayer _audioStreamPlayer;

	public override void _Ready()
	{
		foreach (SoundEffects soundEffect in Enum.GetValues<SoundEffects>())
		{
			string soundPath = Path.Join(basePath, soundEffect.ToString());
			string wavSoundPath = soundPath + wavExtension;
			string oggSoundPath = soundPath + oggExtension;

			AudioStream loadedAudioStream = ResourceLoader.Load<AudioStream>(wavSoundPath);
			if (loadedAudioStream == null)
			{
				loadedAudioStream = ResourceLoader.Load<AudioStream>(oggSoundPath);
			}

			if (loadedAudioStream != null)
			{
				_sounds.Add(soundEffect, loadedAudioStream);
			}
		}

		_audioStreamPlayer = new AudioStreamPlayer();
		AddChild(_audioStreamPlayer);
	}

	public void PlaySound(SoundEffects soundEffectToPlay)
	{
		_audioStreamPlayer.Stream = _sounds[soundEffectToPlay];
		_audioStreamPlayer.Play();
	}
}