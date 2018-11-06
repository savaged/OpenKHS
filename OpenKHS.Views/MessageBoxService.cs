using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using OpenKHS.Interfaces;

namespace OpenKHS.Views
{
    public class MessageBoxService
    {
        public MessageBoxService()
        {
            Messenger.Default.Register<UserFeedbackMessage>(
                this, OnUserFeedbackRequested);
        }

        ~MessageBoxService()
        {
            Messenger.Default.Unregister<UserFeedbackMessage>(this);
        }

        private void OnUserFeedbackRequested(UserFeedbackMessage m)
        {
            if (m is null)
            {
                throw new ArgumentNullException(nameof(m));
            }
            MessageBox.Show(
                m.Body,
                m.Header,
                MessageBoxButton.OK,
                (MessageBoxImage)m.FeedbackType);
        }
    }
}
