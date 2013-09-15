﻿using System;

namespace GadrocsWorkshop.Helios.ComponentModel
{
    /// <summary>
    /// This class extends <see cref="T:PropertyChangingEventArgs"/> and
    /// allows for storing the old and new values of the changed property as
    /// well as ability to validate data.
    /// </summary>
    public class PropertyChangingEventArgs : System.ComponentModel.PropertyChangingEventArgs
    {
        // Source object whose property changed.
        private Object _propertySource;

        // Holds the new value of the property.
        private Object _newValue;

        // Holds the old value of the property.
        private Object _oldValue;

        // Holds the child object that is property belongs to.
        private PropertyChangingEventArgs _childNotification;

        // Holds indicator that this change should be canceled
        private bool _canceled = false;

        // Holds message indicating why this change was canceled.
        private string _message = "";

        #region Constructors

        /// <summary>
        /// Constructs a child notification event based of childs propertynotification
        /// </summary>
        /// <param name="eventSource">Object whose child object has a property changed.</param>
        /// <param name="childPropertyName">Name of the property which represents the child object whose property has chagned.</param>
        /// <param name="childNotification">Event args for child's property notification.</param>
        public PropertyChangingEventArgs(object eventSource, string childPropertyName, PropertyChangingEventArgs childNotification)
            : this(eventSource, childPropertyName, null, null)
        {
            _childNotification = childNotification;
        }

        /// <summary>
        /// Constructs a new notification event for a direct property change.
        /// <see cref="PropertyDataChangedEventArgs"/> class.
        /// </summary>
        /// <param name="eventSource">Object whose property has changed.</param>
        /// <param name="propertyName">
        /// The name of the property that is associated with this
        /// notification.
        /// </param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public PropertyChangingEventArgs(object eventSource, String propertyName, Object oldValue, Object newValue)
            : base(propertyName)
        {
            _propertySource = eventSource;
            _oldValue = oldValue;
            _newValue = newValue;
        }

        #endregion // Constructors

        #region Properties

        public Object PropertySource
        {
            get { return _propertySource; }
        }

        public bool HasChildNotification
        {
            get { return _childNotification != null; }
        }

        public PropertyChangingEventArgs ChildNotification
        {
            get { return _childNotification; }
        }

        /// <summary>
        /// Gets the new value of the property.
        /// </summary>
        /// <value>The new value.</value>
        public Object NewValue
        {
            get
            {
                return this._newValue;
            }
        }

        /// <summary>
        /// Gets the old value of the property.
        /// </summary>
        /// <value>The old value.</value>
        public Object OldValue
        {
            get
            {
                return this._oldValue;
            }
        }

        /// <summary>
        /// Gets or sets flag indicating this change should be canceled.
        /// </summary>
        public bool Canceled
        {
            get { return _canceled; }
            set { _canceled = value; }
        }

        /// <summary>
        /// Gets or sets message indicating why this change was canceled.
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        #endregion // Properties
    }
}
