using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace GourmetGame.App.Messages;

public class StartGameMessage(String StartGame) : ValueChangedMessage<String>(StartGame);
