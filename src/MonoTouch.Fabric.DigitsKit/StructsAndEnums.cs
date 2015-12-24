using ObjCRuntime;

namespace MonoTouch.Fabric.DigitsKit
{
	[Native]
	public enum DGTContactAccessAuthorizationStatus : long
	{
		Pending = 0,
		Denied = 1,
		Accepted = 2
	}

	[Native]
	public enum DGTErrorCode : long
	{
		UnspecifiedError = 0,
		UserCanceledAuthentication = 1,
		UnableToAuthenticateNumber = 2,
		UnableToConfirmNumber = 3,
		UnableToAuthenticatePin = 4,
		UserCanceledFindContacts = 5,
		UserDeniedAddressBookAccess = 6,
		FailedToReadAddressBook = 7,
		UnableToUploadContacts = 8,
		UnableToDeleteContacts = 9,
		UnableToLookupContactMatches = 10
	}
}

