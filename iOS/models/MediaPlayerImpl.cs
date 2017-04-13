﻿using System;
using JobSiteRadio.iOS;
using MediaPlayer;
using Xamarin.Forms;


[assembly: Dependency(typeof(MediaPlayerImpl))]
namespace JobSiteRadio.iOS
{
	
	public class MediaPlayerImpl : IMediaPlayer
	{
		public MediaPlayerImpl()
		{
		}

		public void Backward()
		{
			MPMusicPlayerController.SystemMusicPlayer.SkipToPreviousItem();
		}

		public void Forward()
		{
			MPMusicPlayerController.SystemMusicPlayer.SkipToNextItem();
		}

		public NowPlayingData getNowPlaying()
		{
			var ret = new NowPlayingData();
			try
			{
				MPMusicPlayerController player = MPMusicPlayerController.SystemMusicPlayer;
				if (player.NowPlayingItem != null)
				{
					ret.Title = player.NowPlayingItem.Title;
                    ret.Artist = player.NowPlayingItem.Artist;
                    ret.PlaybackDuration = player.NowPlayingItem.PlaybackDuration;
                    ret.CurrentPlaybackTime = player.CurrentPlaybackTime;
                    ret.Volume = MPMusicPlayerController.SystemMusicPlayer.Volume;
                }
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return ret;

		}

		public void Pause()
		{
			MPMusicPlayerController.SystemMusicPlayer.Pause();

		}

		public void Play()
		{
			
			MPMusicPlayerController.SystemMusicPlayer.Play();
            

        }

		public void SetVolume(float volume)
		{
			MPMusicPlayerController.SystemMusicPlayer.Volume = volume;
		}
	}
}
