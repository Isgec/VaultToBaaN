Imports System
Imports System.IO
Public Class SoapExceptionReader
  Private Shared Sub CreateErrorCode()
    Dim strArray As String() = File.ReadAllLines("D:\ISGEC\VaultErrorCode.csv")
    WriteCodeLine("switch (errorCode)")
    WriteCodeLine("{")
    For Each str As String In strArray
      Dim strArray2 As String() = str.Split(New Char() {","c})
      If strArray2.Length > 2 Then
        WriteCodeLine("case """ + strArray2(0) + """:")
        WriteCodeLine("errorName = """ + strArray2(1) + """;")
        WriteCodeLine("errorDescription = """ + strArray2(2) + """;")
        WriteCodeLine("break;")
      End If
    Next
    WriteCodeLine("}")
  End Sub

  Public Shared Sub GetErrorDetails(ByVal errorCode As String, ByRef errorName As String, ByRef errorDescription As String)
    Select Case errorCode
      Case "0"
        errorName = "UnspecifiedSystemException"
        errorDescription = "Used when the error code is invalid."
        Return

      Case "100"
        errorName = "CreateKnowledgeVaultDatabase"
        errorDescription = "Error creating the knowledge vault."
        Return

      Case "102"
        errorName = "DatabaseExists"
        errorDescription = "Database already exists."
        Return

      Case "106"
        errorName = "TransactionInvalidPrincipal"
        errorDescription = "An example would be making a call without being logged into a vault for methods that require a vault"
        Return

      Case "108"
        errorName = "TransactionManagementError"
        errorDescription = "Cannot create database connection and/or transaction"
        Return

      Case "109"
        errorName = "DatabaseError"
        errorDescription = "Generic error for unexpected database issues."
        Return

      Case "111"
        errorName = "BadResourceRelativePath"
        errorDescription = "General error for failures to store or access a resource in the file store"
        Return

      Case "114"
        errorName = "CreateSystemMasterDatabase"
        errorDescription = "could not create KnowledgeVaultMaster Database"
        Return

      Case "130"
        errorName = "UnknownVersion"
        errorDescription = "Unable to determine the version of a KnowledgeVault or Master"
        Return

      Case "131"
        errorName = "InvalidAdminDbLogin"
        errorDescription = "The database admin login is invalid"
        Return

      Case "132"
        errorName = "DirectoryNotEmpty"
        errorDescription = "The directory is not empty"
        Return

      Case "133"
        errorName = "KnowledgeVaultDoesNotExist"
        errorDescription = "The Knowledge Vault referenced doesn't exist"
        Return

      Case "134"
        errorName = "KnowledgeVaultsAttached"
        errorDescription = "There are Knowledge Vaults still attached."
        Return

      Case "137"
        errorName = "IllegalInputParam"
        errorDescription = "One of the inputs to the service call is incorrect."
        Return

      Case "138"
        errorName = "IllegalDatabaseName"
        errorDescription = "Database name is not allowed. Most likely due to illegal characters."
        Return

      Case "139"
        errorName = "IllegalPath"
        errorDescription = "Specified folder is illegal."
        Return

      Case "140"
        errorName = "DuplicatePath"
        errorDescription = "Specified folder is already in use."
        Return

      Case "143"
        errorName = "UserAlreadyExists"
        errorDescription = "Duplicate User Name"
        Return

      Case "144"
        errorName = "DbFileAlreadyExists"
        errorDescription = "Database error because an MDF or LDF file with that name already exists."
        Return

      Case "146"
        errorName = "MigrationPathNotFound"
        errorDescription = "Cannot determine the migration steps."
        Return

      Case "147"
        errorName = "PathTooLong"
        errorDescription = "The specified path is too long."
        Return

      Case "148"
        errorName = "UnsupportedProduct"
        errorDescription = "The vault has a product installed that is not installed on the server"
        Return

      Case "150"
        errorName = "KnowledgeVaultMasterDoesNotExist"
        errorDescription = "The KnowledgeVaultMaster referenced doesn't exist"
        Return

      Case "152"
        errorName = "IllegalRestoreDBLocation"
        errorDescription = "Cannot restore db files to a remote location"
        Return

      Case "153"
        errorName = "InvalidBackupDirectory"
        errorDescription = "Selected directory does not contain a valid backup structure."
        Return

      Case "154"
        errorName = "InvalidUserId"
        errorDescription = "The user ID is not valid"
        Return

      Case "155"
        errorName = "IllegalNullParam"
        errorDescription = "A null value was passed in where a null value is not allowed."
        Return

      Case "157"
        errorName = "AdministratorCannotBeRemoved"
        errorDescription = ""
        Return

      Case "158"
        errorName = "CircularReference"
        errorDescription = ""
        Return

      Case "160"
        errorName = "BadId"
        errorDescription = ""
        Return

      Case "164"
        errorName = "MigrationXmlError"
        errorDescription = "migrations.xml identifies the .sql scripts and C# code that need to be executed for the different migration paths (e.g., R2 to R3, etc.)"
        Return

      Case "165"
        errorName = "KnowledgeLibraryDoesNotExist"
        errorDescription = "Occurs during restore - also see KnowledgeVaultDoesNotExist:133)"
        Return

      Case "167"
        errorName = "AttachWrongDatabaseType"
        errorDescription = ""
        Return

      Case "171"
        errorName = "DuplicateLibraryGuid"
        errorDescription = "There is already a KnowledgeLibrary with the same GUID"
        Return

      Case "173"
        errorName = "ReadOnlyFile"
        errorDescription = "Trying to perform a write operation on a read-only file"
        Return

      Case "174"
        errorName = "InvalidDatabaseCollation"
        errorDescription = "Trying to create a KVM with an invalid database collation (eg case sensitive)"
        Return

      Case "175"
        errorName = "InsufficientFilePermissions"
        errorDescription = "The user {1} does not have permission to the path {0}"
        Return

      Case "176"
        errorName = "GroupDoesNotExist"
        errorDescription = ""
        Return

      Case "179"
        errorName = "IOError"
        errorDescription = "IOException has been thrown. IOException.Message={0}"
        Return

      Case "180"
        errorName = "FileDoesNotExist"
        errorDescription = ""
        Return

      Case "185"
        errorName = "IncrementTurnedOff"
        errorDescription = ""
        Return

      Case "186"
        errorName = "IncRestoreInEligibleForAdminDataDirty"
        errorDescription = ""
        Return

      Case "187"
        errorName = "IncRestoreInEligibleForUserDataDirty"
        errorDescription = ""
        Return

      Case "188"
        errorName = "IncRestoreInEligibleForBadStateId"
        errorDescription = ""
        Return

      Case "189"
        errorName = "IncBackupInEligibleForAdminDataDirty"
        errorDescription = ""
        Return

      Case "190"
        errorName = "IncBackupInEligibleForUserDataNotdirty"
        errorDescription = ""
        Return

      Case "191"
        errorName = "IncBackupInEligibleForFullBackupUndone"
        errorDescription = ""
        Return

      Case "192"
        errorName = "MissingBackupPackages"
        errorDescription = ""
        Return

      Case "193"
        errorName = "ContentfileWrongFormatted"
        errorDescription = ""
        Return

      Case "194"
        errorName = "IncRestoreInEligibleForWrongIncrement"
        errorDescription = ""
        Return

      Case "196"
        errorName = "LibraryPartitionDoesNotExist"
        errorDescription = ""
        Return

      Case "197"
        errorName = "LibraryPartitionUpdateDoesNotExist"
        errorDescription = ""
        Return

      Case "198"
        errorName = "DatabaseServerNotCompatible"
        errorDescription = ""
        Return

      Case "199"
        errorName = "SystemTypeNotEditable"
        errorDescription = ""
        Return

      Case "200"
        errorName = "NonmemberSite"
        errorDescription = ""
        Return

      Case "201"
        errorName = "DatabaseLocked"
        errorDescription = "{0} is the name of the locking operation. {1} [currently unused] is the name of the database"
        Return

      Case "204"
        errorName = "InvalidSiteName"
        errorDescription = ""
        Return

      Case "205"
        errorName = "CouldNotReplicate"
        errorDescription = ""
        Return

      Case "207"
        errorName = "NoFilestore"
        errorDescription = ""
        Return

      Case "208"
        errorName = "InvalidVaultSite"
        errorDescription = ""
        Return

      Case "211"
        errorName = "VaultDisabled"
        errorDescription = ""
        Return

      Case "212"
        errorName = "FileStoreMismatch"
        errorDescription = "There is a sentinal file with a vaultguid in the root of the filestore. This value needs to match the guid identity of the vault"
        Return

      Case "213"
        errorName = "OrphanedMetaData"
        errorDescription = ""
        Return

      Case "214"
        errorName = "RoleDoesNotExist"
        errorDescription = ""
        Return

      Case "215"
        errorName = "InvalidSystemDbLogin"
        errorDescription = "The system user [vaultsys] either doesn't exist or doesn't match the web.config password"
        Return

      Case "216"
        errorName = "GroupAlreadyExists"
        errorDescription = "Duplicate Group Name"
        Return

      Case "217"
        errorName = "DuplicateVaultGuid"
        errorDescription = ""
        Return

      Case "222"
        errorName = "ChecksumValidationFailure"
        errorDescription = ""
        Return

      Case "223"
        errorName = "RestoringUnsupportedProducts"
        errorDescription = "Restore failed due to product difference between the server and the backup. "
        Return

      Case "224"
        errorName = "InvalidServiceExtensionConfig"
        errorDescription = "At least one type or method referenced in the ServiceExtenstions.xml file could not be resolved."
        Return

      Case "226"
        errorName = "LuceneSearchError"
        errorDescription = "Wrap any errors thrown by Lucene when searching."
        Return

      Case "227"
        errorName = "LuceneIndexingError"
        errorDescription = "Wrap any errors thrown by Lucene when indexing."
        Return

      Case "228"
        errorName = "InvalidServiceExtensionMethod"
        errorDescription = "Wrap any errors thrown when invoking a service extension method."
        Return

      Case "230"
        errorName = "PropertyParsingFailed"
        errorDescription = "Search failed to parse a property value."
        Return

      Case "231"
        errorName = "DatabaseDeadlock"
        errorDescription = "Generic error for unexpected database issues."
        Return

      Case "232"
        errorName = "ConfigurationError"
        errorDescription = "Error occurred calling a config section handler"
        Return

      Case "233"
        errorName = "DatabaseLogFull"
        errorDescription = ""
        Return

      Case "234"
        errorName = "ArraysOfDifferentSizes"
        errorDescription = "Input arrays were of different lengths."
        Return

      Case "236"
        errorName = "UnsupportedParameterType"
        errorDescription = ""
        Return

      Case "237"
        errorName = "DuplicateQueuedEvent"
        errorDescription = ""
        Return

      Case "238"
        errorName = "InvalidEventClass"
        errorDescription = ""
        Return

      Case "239"
        errorName = "UnreserveEventFailed"
        errorDescription = ""
        Return

      Case "240"
        errorName = "JobQueueDisabled"
        errorDescription = ""
        Return

      Case "241"
        errorName = "UnsupportedOperation"
        errorDescription = ""
        Return

      Case "242"
        errorName = "DuplicatePropertiesCannotBeToSamePropertyDef"
        errorDescription = ""
        Return

      Case "243"
        errorName = "PropertiesCannotHaveTheSamePriority"
        errorDescription = ""
        Return

      Case "244"
        errorName = "FailedToLoadPropertyProviderForProp"
        errorDescription = ""
        Return

      Case "245"
        errorName = "InvalidPropertyForPropertyProvider"
        errorDescription = ""
        Return

      Case "246"
        errorName = "IncompatiblePropertyDataTypes"
        errorDescription = ""
        Return

      Case "247"
        errorName = "CannotCreateNewForProperty"
        errorDescription = ""
        Return

      Case "248"
        errorName = "PropertyDoesNotSupportMappingDir"
        errorDescription = ""
        Return

      Case "249"
        errorName = "InvalidEntityClassId"
        errorDescription = ""
        Return

      Case "250"
        errorName = "CannotFindPropertyDefBySystemName"
        errorDescription = ""
        Return

      Case "251"
        errorName = "CannotCreatePropertyDef"
        errorDescription = ""
        Return

      Case "252"
        errorName = "CannotCreatePropertyDef_DisplayNameExists"
        errorDescription = ""
        Return

      Case "253"
        errorName = "PropertyDefIdDoesNotExist"
        errorDescription = ""
        Return

      Case "255"
        errorName = "PropertyDefIsNotMappedToEntityClass"
        errorDescription = ""
        Return

      Case "256"
        errorName = "SystemPropertyDefsCannotChangeThierEnitityClassMappings"
        errorDescription = ""
        Return

      Case "257"
        errorName = "CannotDeleteMappingsWhichAreInUseByEnts"
        errorDescription = ""
        Return

      Case "258"
        errorName = "PropertyDefDisplayNameExist"
        errorDescription = ""
        Return

      Case "259"
        errorName = "ContentSourcePropertyDefIdDoesNotExist"
        errorDescription = ""
        Return

      Case "260"
        errorName = "SystemPropertyDefsCannotBeDeleted"
        errorDescription = ""
        Return

      Case "261"
        errorName = "PropertyDefsCannotBeDeletedWithEntityRefs"
        errorDescription = ""
        Return

      Case "262"
        errorName = "CtntSrcPropProviderNotFound"
        errorDescription = ""
        Return

      Case "263"
        errorName = "BadNumberingSchemeId"
        errorDescription = ""
        Return

      Case "264"
        errorName = "NumberingSchemeIsDefault"
        errorDescription = ""
        Return

      Case "265"
        errorName = "DuplicateNumberSchemeName"
        errorDescription = ""
        Return

      Case "266"
        errorName = "NumberingSchemeInUse"
        errorDescription = ""
        Return

      Case "267"
        errorName = "LastNumberingSchemeCannotBeRemoved"
        errorDescription = ""
        Return

      Case "268"
        errorName = "GetNumberingSchemesBySchemeStatusFailed"
        errorDescription = ""
        Return

      Case "269"
        errorName = "ActivateNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "270"
        errorName = "DeactivateNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "271"
        errorName = "SetDefaultNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "272"
        errorName = "AddNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "273"
        errorName = "UpdateNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "274"
        errorName = "DeleteNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "275"
        errorName = "DeleteNumberingSchemeUnconditionalFailed"
        errorDescription = ""
        Return

      Case "276"
        errorName = "MethodNotSupportedWithBaseVaultServer"
        errorDescription = ""
        Return

      Case "277"
        errorName = "PropertyDefRequiresEntityClassMapping"
        errorDescription = ""
        Return

      Case "278"
        errorName = "PropertyDefDefaultValuesNotSupported"
        errorDescription = ""
        Return

      Case "279"
        errorName = "InvalidEntityClassName"
        errorDescription = ""
        Return

      Case "280"
        errorName = "OnlyReadMappingsSupported"
        errorDescription = ""
        Return

      Case "281"
        errorName = "CreateNewPropertyMappingsNotSupported"
        errorDescription = ""
        Return

      Case "283"
        errorName = "BadEntityId"
        errorDescription = ""
        Return

      Case "284"
        errorName = "EntityClassDoesNotSupportMapping"
        errorDescription = ""
        Return

      Case "285"
        errorName = "EntityClassDoesNotSupportMappingToCSType"
        errorDescription = ""
        Return

      Case "286"
        errorName = "MigrationInProgress"
        errorDescription = ""
        Return

      Case "287"
        errorName = "EntityClassDoesNotSupportLinks"
        errorDescription = ""
        Return

      Case "288"
        errorName = "AddLinkFailed"
        errorDescription = ""
        Return

      Case "289"
        errorName = "CreateNewAndDefaultMappingTypeNotSupported"
        errorDescription = ""
        Return

      Case "290"
        errorName = "UserDefinedPropertyListValuesNotSupported"
        errorDescription = ""
        Return

      Case "291"
        errorName = "UserDefinedPropertyConstraintsNotSupported"
        errorDescription = ""
        Return

      Case "292"
        errorName = "UserDefinedPropertyWithoutCSMappingsNotSupported"
        errorDescription = ""
        Return

      Case "293"
        errorName = "UserDefinedPropertyInitialValuesNotSupported"
        errorDescription = ""
        Return

      Case "294"
        errorName = "LegacyOperationBlocked"
        errorDescription = "This error means that an older client is communicating with a new server and the newer server no longer supports the legacy operation."
        Return

      Case "296"
        errorName = "DatabaseCopyFileFailed"
        errorDescription = ""
        Return

      Case "297"
        errorName = "DatabaseOffline"
        errorDescription = ""
        Return

      Case "299"
        errorName = "CannotUnzip"
        errorDescription = ""
        Return

      Case "300"
        errorName = "BadAuthenticationToken"
        errorDescription = "This can happen when the web services are restarted."
        Return

      Case "301"
        errorName = "InvalidUserPassword"
        errorDescription = "Username and/or Password is invalid, so user cannot be authenticated."
        Return

      Case "302"
        errorName = "UserNotVaultMember"
        errorDescription = "User is not a member of the vault"
        Return

      Case "303"
        errorName = "PermissionDenied"
        errorDescription = "Invalid permissions for transaction"
        Return

      Case "304"
        errorName = "UserIsDisabled"
        errorDescription = "User is disabled"
        Return

      Case "306"
        errorName = "IncompatibleKnowledgeVault"
        errorDescription = "The compatibility of the Vault doesn't match the server version"
        Return

      Case "307"
        errorName = "IncompatibleKnowledgeMaster"
        errorDescription = "The compatibility of the Knowledge Master doesn't match the server version"
        Return

      Case "308"
        errorName = "RestrictionsOccurred"
        errorDescription = ""
        Return

      Case "309"
        errorName = "FeatureNotAvailable"
        errorDescription = ""
        Return

      Case "310"
        errorName = "IncompatibleKnowledgeLibrary"
        errorDescription = ""
        Return

      Case "311"
        errorName = "InvalidAuthType"
        errorDescription = "Attempted to login through WinAuth login user, but user is of Auth Type Vault. "
        Return

      Case "312"
        errorName = "WinAuthUserNotFound"
        errorDescription = "could be auto create is disabled or could not find a valid AD group"
        Return

      Case "313"
        errorName = "WinAuthAnonymousIdentity"
        errorDescription = "Identity was unauthenticated or anonymous"
        Return

      Case "318"
        errorName = "WinAuthFailed"
        errorDescription = "Unknown WinAuth error occurred."
        Return

      Case "319"
        errorName = "LicensingError"
        errorDescription = ""
        Return

      Case "320"
        errorName = "PermissionTamperingDetected"
        errorDescription = ""
        Return

      Case "321"
        errorName = "WorkgroupDoesNotHaveAdminOwnership"
        errorDescription = ""
        Return

      Case "322"
        errorName = "WorkgroupDoesNotHaveObjectOwnership"
        errorDescription = ""
        Return

      Case "323"
        errorName = "WorkgroupIsSubscriber"
        errorDescription = ""
        Return

      Case "370"
        errorName = "OwnedButNotSynced"
        errorDescription = ""
        Return

      Case "400"
        errorName = "DuplicateRoutingName"
        errorDescription = "The routing name already exists."
        Return

      Case "401"
        errorName = "IncompleteRouting"
        errorDescription = "Must be at least one user assigned to each role."
        Return

      Case "402"
        errorName = "DeactivateRoutingFailed"
        errorDescription = "Can't deactivate the last active routing, or the default routing."
        Return

      Case "403"
        errorName = "DeleteRoutingFailed"
        errorDescription = "Can't delete a routing in use, the last active routing, or the default routing."
        Return

      Case "404"
        errorName = "SetDefaultRoutingFailed"
        errorDescription = "Cannot set a deactive routing to the default."
        Return

      Case "405"
        errorName = "ActionDenied"
        errorDescription = "The user does not have the appropriate routing role to perform the activity."
        Return

      Case "406"
        errorName = "ActionAlreadyPerformed"
        errorDescription = "The user has already performed the activity since the change order last entered the current state."
        Return

      Case "407"
        errorName = "BadRoutingName"
        errorDescription = "Routing name contains illegal characters"
        Return

      Case "408"
        errorName = "BadRoutingNameLength"
        errorDescription = ""
        Return

      Case "501"
        errorName = "FailureToLoadEmailHandler"
        errorDescription = ""
        Return

      Case "502"
        errorName = "ErrorSendingEmail"
        errorDescription = ""
        Return

      Case "503"
        errorName = "ErrorInitializeEmailhandler"
        errorDescription = ""
        Return

      Case "504"
        errorName = "EmailIsConfiguredAsDisabled"
        errorDescription = ""
        Return

      Case "505"
        errorName = "InvalidAttachmentStream"
        errorDescription = ""
        Return

      Case "506"
        errorName = "InvalidAttachmentName"
        errorDescription = ""
        Return

      Case "600"
        errorName = "JobConfigurationError"
        errorDescription = ""
        Return

      Case "601"
        errorName = "FailureToLoadJobHandler"
        errorDescription = ""
        Return

      Case "602"
        errorName = "DuplicateJobHandlerIdFound"
        errorDescription = ""
        Return

      Case "603"
        errorName = "JobIdNotFound"
        errorDescription = ""
        Return

      Case "700"
        errorName = "AddCustomEntityDefFailed"
        errorDescription = ""
        Return

      Case "701"
        errorName = "AddCustomEntityFailed"
        errorDescription = ""
        Return

      Case "702"
        errorName = "DeleteCustomEntityRestrictionsOccurred"
        errorDescription = ""
        Return

      Case "703"
        errorName = "DeleteCustomEntityDefFailed"
        errorDescription = ""
        Return

      Case "704"
        errorName = "UpdateCustomEntityFailed"
        errorDescription = ""
        Return

      Case "705"
        errorName = "UpdateCustomEntityDefFailed"
        errorDescription = ""
        Return

      Case "706"
        errorName = "DuplicateCustomEntityDefName"
        errorDescription = ""
        Return

      Case "707"
        errorName = "CustomEntityDefDisplayNameExceedsMaxLength"
        errorDescription = ""
        Return

      Case "708"
        errorName = "InvalidCustomEntityDefDisplayName"
        errorDescription = ""
        Return

      Case "709"
        errorName = "CustomEntityNameExceedsMaxLength"
        errorDescription = ""
        Return

      Case "1000"
        errorName = "BadFolderId"
        errorDescription = ""
        Return

      Case "1001"
        errorName = "GetLatestVersionFailed"
        errorDescription = ""
        Return

      Case "1003"
        errorName = "BadFileId"
        errorDescription = "This error code should still exist, but none of these items appear to belong here:"
        Return

      Case "1004"
        errorName = "CheckoutFailed"
        errorDescription = "Checkout latest file version failed."
        Return

      Case "1005"
        errorName = "CheckinFailed"
        errorDescription = "Error checking in file version into database."
        Return

      Case "1006"
        errorName = "UndoCheckoutFailed"
        errorDescription = "Error undoing check out of file version."
        Return

      Case "1007"
        errorName = "BadVersionId"
        errorDescription = "Bad version id when getting file version dependents or dependencies by version id."
        Return

      Case "1008"
        errorName = "AddFileExists"
        errorDescription = "Cannot add file because file exists."
        Return

      Case "1009"
        errorName = "AddFileFailed"
        errorDescription = "Cannot add file (unspecified failure)"
        Return

      Case "1010"
        errorName = "NOT USED ANYMORE."
        errorDescription = "NOT USED ANYMORE."
        Return

      Case "1011"
        errorName = "AddFolderExists"
        errorDescription = "Cannot add folder because folder exists."
        Return

      Case "1012"
        errorName = "AddFailedCreateFolder"
        errorDescription = "Cannot add folder (unable to create/make new folder)."
        Return

      Case "1013"
        errorName = "GetFileFailed"
        errorDescription = "Cannot get file (file id is invalid)."
        Return

      Case "1014"
        errorName = "MakeVersionFailed"
        errorDescription = "Cannot create/make version in database."
        Return

      Case "1015"
        errorName = "DeleteFileWithDependencies"
        errorDescription = "Only have file id, not name"
        Return

      Case "1016"
        errorName = "UndoCheckoutWrongUser"
        errorDescription = "Cannot undo checkout because user is not the same as user who checked out file."
        Return

      Case "1017"
        errorName = "UndoCheckoutWrongFolder"
        errorDescription = "Cannot undo checkout because passed in folder id is not the same folder that the file was checked out from."
        Return

      Case "1018"
        errorName = "CheckinNotCheckedOut"
        errorDescription = "Cannot check in file because the file is not currently checked out"
        Return

      Case "1019"
        errorName = "CheckinWrongUser"
        errorDescription = "Cannot check in file because the file is not currently checked out by the same user."
        Return

      Case "1020"
        errorName = "CheckinWrongFolder"
        errorDescription = "Cannot check in file because passed in folder id is not the same folder that the file was checked out from."
        Return

      Case "1021"
        errorName = "CheckoutAlreadyCheckedOut"
        errorDescription = "Cannot check out the file because it is already checked out."
        Return

      Case "1022"
        errorName = "SelfDependency"
        errorDescription = "Only have file version id, not name"
        Return

      Case "1023"
        errorName = "MakeFolderFailed"
        errorDescription = "Cannot create folder in database."
        Return

      Case "1024"
        errorName = "GetFolderFailed"
        errorDescription = "Occurs in these cases:"
        Return

      Case "1025"
        errorName = "GetRootFailed"
        errorDescription = "Cannot get root folder from the database."
        Return

      Case "1026"
        errorName = "LibraryProjectExistsForFileId"
        errorDescription = "File belongs to a library folder."
        Return

      Case "1027"
        errorName = "LibraryProjectExistsForId"
        errorDescription = "Folder is a library folder."
        Return

      Case "1028"
        errorName = "MoveFileFailed"
        errorDescription = "Cannot move file."
        Return

      Case "1029"
        errorName = "MoveFileExists"
        errorDescription = "Only have file id, not name"
        Return

      Case "1030"
        errorName = "ShareFileExists"
        errorDescription = "Only have file id, not name"
        Return

      Case "1031"
        errorName = "DuplicatePropertyDefName"
        errorDescription = ""
        Return

      Case "1034"
        errorName = "RenameFailed"
        errorDescription = "Cannot rename the file because there was some other unexpected error."
        Return

      Case "1035"
        errorName = "MakeDefinitionFailed "
        errorDescription = "Could not create property definition in database."
        Return

      Case "1036"
        errorName = "GetAllPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1037"
        errorName = "GetAllPropertyDefinitinsExtendedFailed"
        errorDescription = ""
        Return

      Case "1038"
        errorName = "**GetFileVersionsByPropertySearchConditionsFailed"
        errorDescription = ""
        Return

      Case "1041"
        errorName = "GetPropertiesFailed"
        errorDescription = ""
        Return

      Case "1042"
        errorName = "AddFolderChildRootInvalid"
        errorDescription = "Create folder rule-check failed:  parent must exist, for all but root"
        Return

      Case "1043"
        errorName = "AddFolderLibraryRelationshipInvalid"
        errorDescription = "Create folder rule-check failed:  libs can only have non lib parent if that parent is root.  libs cannot have non lib children."
        Return

      Case "1044"
        errorName = "ConcurrentShareFailed"
        errorDescription = "Request to share a file to a folder fails because of a concurrent request to share the file to the same folder."
        Return

      Case "1045"
        errorName = "ConcurrentMoveFailed"
        errorDescription = "Request to move a file to a folder fails because of a concurrent request to move the file to the same folder or because of a concurrent request to move the file to another folder"
        Return

      Case "1046"
        errorName = "FolderCharacterLengthInvalid"
        errorDescription = "Request to create a folder fails because the folder name is longer than 255 characters."
        Return

      Case "1047"
        errorName = "DependentExistsAttachmentFailed"
        errorDescription = "Unused"
        Return

      Case "1048"
        errorName = "RenameFailedDependentParentItemsLinked"
        errorDescription = "Unused"
        Return

      Case "1049"
        errorName = "RenameFailedDependentParentItemsAttached"
        errorDescription = "Unused"
        Return

      Case "1050"
        errorName = "DeleteFileFailedRestrictions"
        errorDescription = "Request to conditionally delete a file fails because there are delete restrictions (file has dependent parents files, file is checked out, or file is linked or attached to an item)"
        Return

      Case "1051"
        errorName = "DeleteFileFailedUnconditionalRestrictions"
        errorDescription = "Request to unconditionally delete a file fails because the are delete restrictions that cannot be overridden (file is linked or attached to an item)"
        Return

      Case "1052"
        errorName = "DeleteFileFailed"
        errorDescription = "Request to delete a file failed for an unspecified reason."
        Return

      Case "1053"
        errorName = "DeleteFolderFailedRestrictions"
        errorDescription = "Request to conditionally delete a folder fails because there are delete restrictions on one or more child files (file has dependent parents files, file is checked out, or file is linked or attached to an item)"
        Return

      Case "1054"
        errorName = "DeleteFolderFailedUnconditionalRestrictions"
        errorDescription = "Request to unconditionally delete a folder fails because the are delete restrictions that cannot be overridden on one or more child files (file is linked or attached to an item)"
        Return

      Case "1055"
        errorName = "DeleteFolderFailed"
        errorDescription = "Request to delete a folder fails due to an unspecified reason"
        Return

      Case "1056"
        errorName = "PurgeBadParam "
        errorDescription = "The keep count must be >= 1, and the minimum age must be >= 0"
        Return

      Case "1057"
        errorName = "PurgeFailed"
        errorDescription = "Occurs when something goes wrong while purging file iterations from the database, or while deleting files from the file store"
        Return

      Case "1058"
        errorName = "UniqueFileNameRequiredViolated"
        errorDescription = "If the Unique File Name Required Vault option is ON, a request to Add or Checkin a file with the same name as a file already existing in the Vault will fail with this error."
        Return

      Case "1059"
        errorName = "UpdateFolderFailed"
        errorDescription = "Occurs when an attempt to update a Folder fails for an unspecified reason."
        Return

      Case "1060"
        errorName = "UpdateFolderExists"
        errorDescription = "Occurs when an attempt to update a Folder Name fails because another Folder with that name exists in the parent."
        Return

      Case "1061"
        errorName = "BadLabelId"
        errorDescription = "Label ID is invalid"
        Return

      Case "1062"
        errorName = "BadLabelName"
        errorDescription = "Label Name contains invalid characters"
        Return

      Case "1063"
        errorName = "DuplicateLabel"
        errorDescription = "Label Name already exists in vault"
        Return

      Case "1064"
        errorName = "MakeLabelFailed"
        errorDescription = "Cannot create label in database."
        Return

      Case "1065"
        errorName = "GetAllFilesFailed"
        errorDescription = ""
        Return

      Case "1066"
        errorName = "BadPropertyGroupId"
        errorDescription = ""
        Return

      Case "1067"
        errorName = "PropertyGroupExists"
        errorDescription = ""
        Return

      Case "1069"
        errorName = "PropertyGroupEmpty"
        errorDescription = ""
        Return

      Case "1072"
        errorName = "DeletePropertyGroupFailed"
        errorDescription = ""
        Return

      Case "1073"
        errorName = "MoveFolderFailed"
        errorDescription = "Now used as: documentRestriction_11; documentRestriction_12; documentRestriction_13 in document world."
        Return

      Case "1074"
        errorName = "MoveFolderExists"
        errorDescription = "Folder with the same name already exists in the destination folder"
        Return

      Case "1075"
        errorName = "MoveFolderDescendentCheckedOut"
        errorDescription = "Folder begin moved has descendent files that are checked out."
        Return

      Case "1076"
        errorName = "MoveFolderChildRootInvalid"
        errorDescription = "Move folder rule-check failed:  parent must exist, for all but root"
        Return

      Case "1077"
        errorName = "MoveFolderLibraryRelationshipInvalid"
        errorDescription = "Move folder rule-check failed:  libs can only have non lib parent if that parent is root.  libs cannot have non lib children."
        Return

      Case "1078"
        errorName = "FolderNameInvalid"
        errorDescription = "A null path or path will illegal characters has been passed in."
        Return

      Case "1079"
        errorName = "FolderFullNameTooLong"
        errorDescription = ""
        Return

      Case "1080"
        errorName = "IllegalNullParam"
        errorDescription = "A null value has been passed in where null values are not allowed."
        Return

      Case "1081"
        errorName = "BadDate"
        errorDescription = "The date is out of range for the DB.  The date should be between 1-1-1753 and 12-31-9999"
        Return

      Case "1082"
        errorName = "ArraysOfDifferentSizes"
        errorDescription = "The input arrays were not of the same size"
        Return

      Case "1083"
        errorName = "LabelNameLengthInvalid"
        errorDescription = ""
        Return

      Case "1084"
        errorName = "UndoCheckoutNotCheckedOut"
        errorDescription = "Cannot undo check out of the file because the file is not currently checked out."
        Return

      Case "1085"
        errorName = "BadSearchOperator"
        errorDescription = "The search operator is not valid."
        Return

      Case "1086"
        errorName = "EmptyFolder"
        errorDescription = "The folder being operated on is empty."
        Return

      Case "1087"
        errorName = "IllegalEmptyString"
        errorDescription = "A empty string has been passed in where its is not allowed."
        Return

      Case "1088"
        errorName = "UnknownBOMVersion"
        errorDescription = "BOM information is stored with each file iteration as an xml string.  The xml format differs between Vault releases.  In order to identity the different formats, each string is marked with an namespace.  The server uses the namespace to determine how the xml string should be converted into a BOM object.  If the server encounters a string without a recognized namespace, it will return this code."
        Return

      Case "1089"
        errorName = "InvalidBOMXml"
        errorDescription = "During AddFile and CheckinFile calls, the client can supply BOM information for the file in the form of a OBM object.  The server then sotres this information with the file iteration and it is used during the promot process.  The server validates the BOM information against the defined schema, if validation fails, this code is returned."
        Return

      Case "1090"
        errorName = "BadPropertyDefId"
        errorDescription = "Property Def Id is invalid."
        Return

      Case "1091"
        errorName = "CheckoutFolderInvalid"
        errorDescription = "The file being checked out does not live in the specified folder, therefore it cannot be used as the checkout folder."
        Return

      Case "1092"
        errorName = "RestrictionsOccurred"
        errorDescription = "Restrictions have occurred. More information available in SoapException detail."
        Return

      Case "1093"
        errorName = "GetRestrictionsFailed"
        errorDescription = "Failed trying to determine restrictions."
        Return

      Case "1094"
        errorName = "PropertyGroupPropertyDefMinCount"
        errorDescription = "Property groups must include a minimum of 2 property definitions."
        Return

      Case "1098"
        errorName = "MoveFileLocked"
        errorDescription = "The file cannot be moved because it is locked"
        Return

      Case "1100"
        errorName = "UploadFileDoesNotExist"
        errorDescription = ""
        Return

      Case "1101"
        errorName = "DownloadFileSizeExceedsServerLimit"
        errorDescription = ""
        Return

      Case "1102"
        errorName = "UpdatePropertyDefinitionFailed"
        errorDescription = ""
        Return

      Case "1103"
        errorName = "CheckinFailedAssociatedFileCheckedout"
        errorDescription = ""
        Return

      Case "1104"
        errorName = "SetFileStatusFailed"
        errorDescription = ""
        Return

      Case "1106"
        errorName = "FullContentSearchContentIndexingDisabled"
        errorDescription = "The client has submitted a search against file content but the Vault Content Indexing is disabled."
        Return

      Case "1107"
        errorName = "DimeAttachmentExpected"
        errorDescription = "This error will be raised if AddFile or UploadFilePart is called without including a DIME attachment."
        Return

      Case "1108"
        errorName = "BadFileName"
        errorDescription = "This error will be raised by AddFile and AddUploadedFile is the filename supplied for the new file is null, empty or contains invalid characters.  CheckinFile and CheckinUploadedFile will raise this error if the newFilename propvided contains invalid characters."
        Return

      Case "1109"
        errorName = "ComponentCustomPropertyDefExists"
        errorDescription = ""
        Return

      Case "1110"
        errorName = "ParamNameInvalid"
        errorDescription = ""
        Return

      Case "1111"
        errorName = "DuplicateFileNamingSchemeExists"
        errorDescription = ""
        Return

      Case "1112"
        errorName = "AddFileNamingSchemeFailed"
        errorDescription = ""
        Return

      Case "1113"
        errorName = "UpdateFileNamingSchemeFailed"
        errorDescription = ""
        Return

      Case "1114"
        errorName = "FileExistsRemotely"
        errorDescription = ""
        Return

      Case "1115"
        errorName = "FileDoesNotExists"
        errorDescription = ""
        Return

      Case "1116"
        errorName = "SaveFilterConfigFailed"
        errorDescription = "Raised when the Filter Config information cannot be saved to disk."
        Return

      Case "1117"
        errorName = "BadFileNamingScheme"
        errorDescription = ""
        Return

      Case "1118"
        errorName = "RollbackFileNamingDescriptionsFailed"
        errorDescription = ""
        Return

      Case "1119"
        errorName = "ReserveFileNamingDescriptionsFailed"
        errorDescription = ""
        Return

      Case "1120"
        errorName = "FolderFileNameCollision"
        errorDescription = "AddFile, CheckinFile, MoveFile, ShareFile, AddFolder"
        Return

      Case "1121"
        errorName = "CreateUserDefinedPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1122"
        errorName = "BadPropertyReindexError"
        errorDescription = ""
        Return

      Case "1123"
        errorName = "IdentifyFilesForPropertyReindexFailed"
        errorDescription = ""
        Return

      Case "1124"
        errorName = "AddDesignVisualizationAttachmentBadFileClassification"
        errorDescription = ""
        Return

      Case "1125"
        errorName = "AddDesignVisualizationAttachmentBadAttachmentOrder"
        errorDescription = ""
        Return

      Case "1126"
        errorName = "AddDesignVisualizationAttachmentExists"
        errorDescription = ""
        Return

      Case "1127"
        errorName = "SetDesignVisualizationStatusFileCheckedOut"
        errorDescription = ""
        Return

      Case "1128"
        errorName = "SetDesignVisualizationStatusInvalidStatus"
        errorDescription = ""
        Return

      Case "1129"
        errorName = "GenerateFileNumberFailed"
        errorDescription = ""
        Return

      Case "1130"
        errorName = "GenerateFileNumberFailedAutoFieldNumberUsedUp"
        errorDescription = ""
        Return

      Case "1131"
        errorName = "FileRenameReleasedParent"
        errorDescription = ""
        Return

      Case "1132"
        errorName = "WarningThresholdGreaterThanMaximumThreshold"
        errorDescription = ""
        Return

      Case "1133"
        errorName = "ThresholdOutOfRange"
        errorDescription = ""
        Return

      Case "1134"
        errorName = "ExceedBulkFileMaximumThreshold"
        errorDescription = ""
        Return

      Case "1135"
        errorName = "FailureToSaveFileForProviderUse"
        errorDescription = ""
        Return

      Case "1136"
        errorName = "UpdateFilePropertiesNotCheckedOut"
        errorDescription = ""
        Return

      Case "1137"
        errorName = "CannotCheckoutNontipFileVersion"
        errorDescription = ""
        Return

      Case "1138"
        errorName = "FileUploadRequired"
        errorDescription = "This checkin operation requires an uploaded file."
        Return

      Case "1139"
        errorName = "FileUploadInuse"
        errorDescription = "This upload ticket has already been used."
        Return

      Case "1140"
        errorName = "FileUploadWrongExtension"
        errorDescription = "The uploaded file extension doesn't match the file name"
        Return

      Case "1200"
        errorName = "SerializeNullObject"
        errorDescription = ""
        Return

      Case "1300"
        errorName = "BadId"
        errorDescription = "Occurs when item revision ID is bad, user ID is bad"
        Return

      Case "1301"
        errorName = "BadUserId"
        errorDescription = "The user ID couldn't be used to create an item revision"
        Return

      Case "1302"
        errorName = "BadItemRevision"
        errorDescription = "The item revision couldn't be used to create the new item revision"
        Return

      Case "1303"
        errorName = "BadMasterItemId"
        errorDescription = "The master item ID didn't return the tip item revision"
        Return

      Case "1304"
        errorName = "BadRevisionNumber"
        errorDescription = "Item revision is less than or equal to current revision"
        Return

      Case "1305"
        errorName = "BadRevisionNumberFormat"
        errorDescription = "Item revision isn't in current revision scheme"
        Return

      Case "1306"
        errorName = "UpdateItemsFailed"
        errorDescription = "The item or unpinned item iteration associations could not be updated"
        Return

      Case "1307"
        errorName = "UpdateItemFailed"
        errorDescription = "The item, its attachments, or unpinned item iteration associations could not be updated"
        Return

      Case "1308"
        errorName = "DeleteItemsFailed"
        errorDescription = "Item could not be deleted"
        Return

      Case "1309"
        errorName = "GetTipItemRevisionsFailed"
        errorDescription = "Tip item revisions could not be retrieved "
        Return

      Case "1310"
        errorName = "GetItemRevisionHistoryFailed"
        errorDescription = "Item revision history could not be retrieved"
        Return

      Case "1311"
        errorName = "GetTipItemRevisionFailed"
        errorDescription = "Item revision could not be retrieved. Please refresh and try again"
        Return

      Case "1312"
        errorName = "GetRolledUpBOMFailed"
        errorDescription = "Rolled up BOM could not be retrieved"
        Return

      Case "1313"
        errorName = "GetAllBOMLinksAndRevisionsFailed"
        errorDescription = "BOM links and revisions could not be retrieved"
        Return

      Case "1314"
        errorName = "BOMCompareFailed"
        errorDescription = "The selected BOMs could not be compared"
        Return

      Case "1315"
        errorName = "GetNextRevisionOptionsFailed"
        errorDescription = "Next revision options could not be retrieved"
        Return

      Case "1316"
        errorName = "PromoteFileIterationsFailed"
        errorDescription = "File iterations could not be promoted"
        Return

      Case "1317"
        errorName = "UpdateItemsFromFilesFailed"
        errorDescription = "Could not update items from files"
        Return

      Case "1318"
        errorName = "GetPromoteUpdateRestrictionsFailed"
        errorDescription = "Could not get restrictions for promote and udpate"
        Return

      Case "1319"
        errorName = "GetItemUpdateRestrictionsFailed"
        errorDescription = ""
        Return

      Case "1320"
        errorName = "CreateItemRevisionFailed"
        errorDescription = "Could not create an item revision"
        Return

      Case "1321"
        errorName = "EditItemRevisionFailed"
        errorDescription = "Could not get item revision to edit"
        Return

      Case "1322"
        errorName = "DeleteItemIterationsFailed"
        errorDescription = "Could not delete item iterations"
        Return

      Case "1323"
        errorName = "GetLifeCycleDefsFailed"
        errorDescription = "Could not get lifecycle definitions"
        Return

      Case "1324"
        errorName = "GetItemIterationAttachmentsFailed"
        errorDescription = "Could not get item iteration attachments"
        Return

      Case "1325"
        errorName = "GetItemFileLinksFailed"
        errorDescription = "Could not get file links for item"
        Return

      Case "1326"
        errorName = "GetLifeCycleStateChangeRestrictionsFailed"
        errorDescription = "Could not get restrictions for lifecycle state changes"
        Return

      Case "1327"
        errorName = "BulkChangeLifeCycleFailed"
        errorDescription = "Could not perform bulk lifecycle change"
        Return

      Case "1328"
        errorName = "GetItemRevisionsForFileFailed"
        errorDescription = ""
        Return

      Case "1329"
        errorName = "GetUserDefinedPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1330"
        errorName = "CreateUserDefinedPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1333"
        errorName = "DeleteUnitOfMeasureFailed"
        errorDescription = ""
        Return

      Case "1334"
        errorName = "CreateUnitOfMeasureFailed"
        errorDescription = ""
        Return

      Case "1335"
        errorName = "EditUnitOfMeasureFailed"
        errorDescription = ""
        Return

      Case "1336"
        errorName = "GetUnitOfMeasureFailed"
        errorDescription = ""
        Return

      Case "1337"
        errorName = "GetAllUnitsOfMeasureFailed"
        errorDescription = ""
        Return

      Case "1338"
        errorName = "GetBaseUnitsOfMeasureFailed"
        errorDescription = ""
        Return

      Case "1339"
        errorName = "GetUnitOfMeasureFamilyFailed"
        errorDescription = ""
        Return

      Case "1341"
        errorName = "CreateItemNumberFailed"
        errorDescription = ""
        Return

      Case "1344"
        errorName = "DeleteUnusedItemNumbersFailed"
        errorDescription = ""
        Return

      Case "1349"
        errorName = "GetEditItemRevisionRestrictionsFailed"
        errorDescription = ""
        Return

      Case "1350"
        errorName = "GetLatestItemRevisionByItemNumberFailed"
        errorDescription = ""
        Return

      Case "1351"
        errorName = "GetChangeItemNumberRestrictionsFailed"
        errorDescription = ""
        Return

      Case "1352"
        errorName = "GetChangeItemRevisionNumberRestrictionsFailed"
        errorDescription = ""
        Return

      Case "1358"
        errorName = "BadUnitOfMeasure"
        errorDescription = ""
        Return

      Case "1361"
        errorName = "ZeroDefaultRevisionSchemeAssignedToCategory"
        errorDescription = ""
        Return

      Case "1362"
        errorName = "PromoteFileIterationsConcurrencyFailed"
        errorDescription = "Could not promote files due to concurrency issues."
        Return

      Case "1364"
        errorName = "InvalidLock"
        errorDescription = "An Invalid Lock has occurred.  You were not able to obtain a lock for this operation or your lock expired."
        Return

      Case "1365"
        errorName = "GetDeleteItemRestrictionsFailed"
        errorDescription = ""
        Return

      Case "1366"
        errorName = "GetAllBOMStructureTypesFailed"
        errorDescription = ""
        Return

      Case "1367"
        errorName = "DuplicateName"
        errorDescription = ""
        Return

      Case "1368"
        errorName = "DuplicateId"
        errorDescription = ""
        Return

      Case "1369"
        errorName = "EntityInUse"
        errorDescription = ""
        Return

      Case "1370"
        errorName = "InvalidArrayLength"
        errorDescription = ""
        Return

      Case "1371"
        errorName = "GetItemTypeByIdFailed"
        errorDescription = ""
        Return

      Case "1372"
        errorName = "GetAllItemTypesFailed"
        errorDescription = ""
        Return

      Case "1373"
        errorName = "AddItemTypeFailed"
        errorDescription = ""
        Return

      Case "1374"
        errorName = "UpdateItemTypeFailed"
        errorDescription = ""
        Return

      Case "1375"
        errorName = "DeleteItemTypeFailed"
        errorDescription = ""
        Return

      Case "1376"
        errorName = "AddRevisionSequenceSchemeFailed"
        errorDescription = ""
        Return

      Case "1377"
        errorName = "AddRevisionFormatFailed"
        errorDescription = ""
        Return

      Case "1378"
        errorName = "GetAllRevisionFormatsFailed"
        errorDescription = ""
        Return

      Case "1379"
        errorName = "GetAllRevisionSequenceSchemesFailed"
        errorDescription = ""
        Return

      Case "1381"
        errorName = "UpdateItemIterationBOMLinksFailed"
        errorDescription = "Update BOM failed."
        Return

      Case "1384"
        errorName = "NotEditable"
        errorDescription = ""
        Return

      Case "1385"
        errorName = "SetItemLifeCycleStateFailed"
        errorDescription = ""
        Return

      Case "1386"
        errorName = "GetItemIterationsByIterationIdsFailed"
        errorDescription = ""
        Return

      Case "1387"
        errorName = "RestrictionsOccurred"
        errorDescription = ""
        Return

      Case "1388"
        errorName = "GetRestrictionsFailed"
        errorDescription = ""
        Return

      Case "1389"
        errorName = "IncompatibleDataType"
        errorDescription = ""
        Return

      Case "1390"
        errorName = "EntityDeleted"
        errorDescription = ""
        Return

      Case "1391"
        errorName = "CircularReference"
        errorDescription = ""
        Return

      Case "1392"
        errorName = "DuplicatePriority"
        errorDescription = ""
        Return

      Case "1393"
        errorName = "DuplicateMapping"
        errorDescription = ""
        Return

      Case "1394"
        errorName = "GetMappablePropertyDefsFailed"
        errorDescription = ""
        Return

      Case "1396"
        errorName = "UpdateItemEffectivityFailed"
        errorDescription = ""
        Return

      Case "1398"
        errorName = "GetRestorableItemRevisionsFailed"
        errorDescription = ""
        Return

      Case "1399"
        errorName = "RestoreItemFailed"
        errorDescription = ""
        Return

      Case "1400"
        errorName = "GetItemPropertiesFailed"
        errorDescription = ""
        Return

      Case "1401"
        errorName = "GetAllItemPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1402"
        errorName = "DuplicateLabel"
        errorDescription = ""
        Return

      Case "1403"
        errorName = "IntrinsicPropertyNameCollision"
        errorDescription = ""
        Return

      Case "1404"
        errorName = "GetItemRevisionByItemIterationIDFailed"
        errorDescription = ""
        Return

      Case "1405"
        errorName = "BadItemIterationId"
        errorDescription = "Item version identified incorrectly."
        Return

      Case "1406"
        errorName = "ItemNumberInUse"
        errorDescription = ""
        Return

      Case "1407"
        errorName = "RevisionSequenceSchemeLengthGreaterThan16"
        errorDescription = ""
        Return

      Case "1408"
        errorName = "GetRollbackItemLifeCycleStatesInfoFailed"
        errorDescription = "Could not retreive rollback information."
        Return

      Case "1409"
        errorName = "RollbackItemLifeCycleStatesFailed"
        errorDescription = ""
        Return

      Case "1410"
        errorName = "RollbackItemLifeCycleStatesCancelFailed"
        errorDescription = ""
        Return

      Case "1411"
        errorName = "GetItemRefDesPropertiesFailed"
        errorDescription = ""
        Return

      Case "1412"
        errorName = "GetAllItemRefDesPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1413"
        errorName = "DuplicateBomSchemeName"
        errorDescription = ""
        Return

      Case "1414"
        errorName = "GetItemDuplicateCandidatesFailed"
        errorDescription = ""
        Return

      Case "1415"
        errorName = "ReassignComponentsToDifferentItemsFailed"
        errorDescription = ""
        Return

      Case "1416"
        errorName = "GetReleasedRevisionsFailed"
        errorDescription = ""
        Return

      Case "1417"
        errorName = "GetBOMFailedNothingEffective"
        errorDescription = ""
        Return

      Case "1418"
        errorName = "GetDWFWatermarksByItemIdFailed"
        errorDescription = ""
        Return

      Case "1419"
        errorName = "CreateDWFWatermarkDefinitionFailed"
        errorDescription = ""
        Return

      Case "1420"
        errorName = "GetAllDWFWatermarkDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1421"
        errorName = "GetDWFWatermarkByFileIterationId"
        errorDescription = ""
        Return

      Case "1422"
        errorName = "GetEnableDWFWatermarkingFailed"
        errorDescription = ""
        Return

      Case "1423"
        errorName = "SetEnableDWFWatermarkingFailed"
        errorDescription = ""
        Return

      Case "1424"
        errorName = "UpdateDWFWatermarkDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1425"
        errorName = "BadFileIterationId"
        errorDescription = "File version identified incorrectly."
        Return

      Case "1426"
        errorName = "WatermarkRetrievalFailed"
        errorDescription = ""
        Return

      Case "1427"
        errorName = "DuplicateConstraintDefForProperty"
        errorDescription = "Could not create a property constraint for the property because one of the some type already exists."
        Return

      Case "1428"
        errorName = "InvalidStringLength"
        errorDescription = ""
        Return

      Case "1429"
        errorName = "IllegalUseOfNull"
        errorDescription = ""
        Return

      Case "1430"
        errorName = "PropertyDefinitionDoesNotExist"
        errorDescription = ""
        Return

      Case "1431"
        errorName = "ItemTypeDoesNotExist"
        errorDescription = ""
        Return

      Case "1432"
        errorName = "InvalidConstraintExpression"
        errorDescription = ""
        Return

      Case "1433"
        errorName = "GetItemPackAndGoInfoFailed"
        errorDescription = ""
        Return

      Case "1434"
        errorName = "InvalidPropertyConstraintEntityTypeId"
        errorDescription = ""
        Return

      Case "1435"
        errorName = "GetRestrictLifeCycleStateChangeToChangeOrderFailed"
        errorDescription = ""
        Return

      Case "1436"
        errorName = "SetRestrictLifeCycleStateChangeToChangeOrderFailed"
        errorDescription = ""
        Return

      Case "1437"
        errorName = "BadUnitOfMeasureId"
        errorDescription = ""
        Return

      Case "1442"
        errorName = "GetEnablementConfigurationFailed"
        errorDescription = ""
        Return

      Case "1443"
        errorName = "SetEnablementConfigurationFailed"
        errorDescription = ""
        Return

      Case "1445"
        errorName = "GetItemRevisionByItemNumberAndRevisionNumberFailed"
        errorDescription = ""
        Return

      Case "1446"
        errorName = "GetRestrictAssignDesignFilesFailed"
        errorDescription = ""
        Return

      Case "1447"
        errorName = "SetRestrictAssignDesignFilesFailed"
        errorDescription = ""
        Return

      Case "1448"
        errorName = "GetItemBOMLinksFailed"
        errorDescription = ""
        Return

      Case "1455"
        errorName = "ItemProvisionalComponentDataInvalid"
        errorDescription = ""
        Return

      Case "1500"
        errorName = "System_Error"
        errorDescription = ""
        Return

      Case "1501"
        errorName = "MSMQSendError"
        errorDescription = ""
        Return

      Case "1502"
        errorName = "Export_Get_Configuration_File_Error"
        errorDescription = ""
        Return

      Case "1503"
        errorName = "GetERPPackageError"
        errorDescription = ""
        Return

      Case "1504"
        errorName = "GetDWFPackageError"
        errorDescription = ""
        Return

      Case "1505"
        errorName = "ExportERPPackageError"
        errorDescription = ""
        Return

      Case "1506"
        errorName = "ExportDWFError"
        errorDescription = ""
        Return

      Case "1507"
        errorName = "CreateDWFPackageError"
        errorDescription = ""
        Return

      Case "1508"
        errorName = "ItemServiceError"
        errorDescription = ""
        Return

      Case "1509"
        errorName = "CopyFileError"
        errorDescription = ""
        Return

      Case "1510"
        errorName = "GetRevisionFromIterationIDError"
        errorDescription = ""
        Return

      Case "1511"
        errorName = "GetChildRevisionsError"
        errorDescription = ""
        Return

      Case "1512"
        errorName = "DeleteObsoletFilesError"
        errorDescription = ""
        Return

      Case "1513"
        errorName = "NoValidItemSelected"
        errorDescription = ""
        Return

      Case "1514"
        errorName = "Export_Save_Configuration_File_Error"
        errorDescription = ""
        Return

      Case "1515"
        errorName = "CheckStateError"
        errorDescription = ""
        Return

      Case "1520"
        errorName = "GetImportSystemFailed"
        errorDescription = ""
        Return

      Case "1521"
        errorName = "GetExportSystemFailed"
        errorDescription = ""
        Return

      Case "1522"
        errorName = "ImportFileNotFound"
        errorDescription = ""
        Return

      Case "1523"
        errorName = "ImportFileNotIntegrated"
        errorDescription = ""
        Return

      Case "1524"
        errorName = "InvalidImportFileFormat"
        errorDescription = ""
        Return

      Case "1525"
        errorName = "NoItemExists"
        errorDescription = ""
        Return

      Case "1526"
        errorName = "InvalidItemExists"
        errorDescription = ""
        Return

      Case "1527"
        errorName = "InvalidBOMStructure"
        errorDescription = ""
        Return

      Case "1528"
        errorName = "ReadCSVFileFailed"
        errorDescription = ""
        Return

      Case "1529"
        errorName = "ReadTDLFileFailed"
        errorDescription = ""
        Return

      Case "1530"
        errorName = "ReadXmlFileFailed"
        errorDescription = ""
        Return

      Case "1531"
        errorName = "ReadDwfFileFailed"
        errorDescription = ""
        Return

      Case "1532"
        errorName = "WriteCSVFileFailed"
        errorDescription = ""
        Return

      Case "1533"
        errorName = "WriteTDLFileFailed"
        errorDescription = ""
        Return

      Case "1534"
        errorName = "WriteXmlFileFailed"
        errorDescription = ""
        Return

      Case "1535"
        errorName = "WriteDwfFileFailed"
        errorDescription = ""
        Return

      Case "1536"
        errorName = "AttachmentNotFound"
        errorDescription = ""
        Return

      Case "1537"
        errorName = "AddERPFileToStoreFailed"
        errorDescription = ""
        Return

      Case "1538"
        errorName = "GetERPFileFromStoreFailed"
        errorDescription = ""
        Return

      Case "1539"
        errorName = "InvalidMappingInfo"
        errorDescription = ""
        Return

      Case "1540"
        errorName = "CreateTempItemsAndBOMFailed"
        errorDescription = ""
        Return

      Case "1541"
        errorName = "UpdateTempItemsAndBOMFailed"
        errorDescription = ""
        Return

      Case "1542"
        errorName = "CommitItemsAndBOMFailed"
        errorDescription = ""
        Return

      Case "1543"
        errorName = "GetItemPropertiesFailed"
        errorDescription = ""
        Return

      Case "1544"
        errorName = "GetExportItemInfoFailed"
        errorDescription = ""
        Return

      Case "1545"
        errorName = "GetERPPackageFailed"
        errorDescription = ""
        Return

      Case "1546"
        errorName = "ExportToERPFailed"
        errorDescription = ""
        Return

      Case "1547"
        errorName = "GetImportJobsFailed"
        errorDescription = ""
        Return

      Case "1548"
        errorName = "GetFileFromJobFailed"
        errorDescription = ""
        Return

      Case "1549"
        errorName = "InvalidFileType"
        errorDescription = ""
        Return

      Case "1550"
        errorName = "DirectoryNotExist"
        errorDescription = ""
        Return

      Case "1551"
        errorName = "BomStructureEmpty"
        errorDescription = ""
        Return

      Case "1552"
        errorName = "ItemStructureEmpty"
        errorDescription = ""
        Return

      Case "1553"
        errorName = "DataMapEmpty"
        errorDescription = ""
        Return

      Case "1554"
        errorName = "SendResultsEmailFailed"
        errorDescription = ""
        Return

      Case "1555"
        errorName = "SendResultsEmailAttachmentsError"
        errorDescription = ""
        Return

      Case "1600"
        errorName = "StateHasChanged"
        errorDescription = "The state has changed since the last refresh so the action is not valid."
        Return

      Case "1601"
        errorName = "ActionDenied"
        errorDescription = "OBSOLETE"
        Return

      Case "1602"
        errorName = "UpdateDenied"
        errorDescription = ""
        Return

      Case "1603"
        errorName = "BadApproveDeadline"
        errorDescription = "The approval deadline is in the past"
        Return

      Case "1604"
        errorName = "BadChangeOrderId"
        errorDescription = "No such change order exists with the specified ID"
        Return

      Case "1605"
        errorName = "BadNumberingSchemeId"
        errorDescription = "No such numbering scheme exists for change orders with the specified ID"
        Return

      Case "1606"
        errorName = "BadRoutingId"
        errorDescription = "No routing exists for the change order process with the specified ID"
        Return

      Case "1607"
        errorName = "ChangeOrderNumberExists"
        errorDescription = "Cannot add a change order since the change order number already exists."
        Return

      Case "1608"
        errorName = "GetChangeOrderFailed"
        errorDescription = "Could not find the specified change order"
        Return

      Case "1609"
        errorName = "AddChangeOrderFailed"
        errorDescription = "Unable to add change order"
        Return

      Case "1610"
        errorName = "MissingMasterItemId"
        errorDescription = ""
        Return

      Case "1611"
        errorName = "ChangeOrderLocked"
        errorDescription = "The change order is locked by another user"
        Return

      Case "1612"
        errorName = "ItemOnAnotherChangeOrder"
        errorDescription = "The item is being managed by another change order"
        Return

      Case "1613"
        errorName = "AddChangeOrderTypeFailed"
        errorDescription = "A change order type defines a set of properties that should be attached to a change order."
        Return

      Case "1614"
        errorName = "DuplicateNumberSchemeName"
        errorDescription = ""
        Return

      Case "1615"
        errorName = "NumberingSchemeInUse"
        errorDescription = ""
        Return

      Case "1616"
        errorName = "GetAllChangeOrderTypesFailed"
        errorDescription = "Could not get change order types"
        Return

      Case "1617"
        errorName = "UpdateChangeOrderTypeFailed"
        errorDescription = ""
        Return

      Case "1618"
        errorName = "GetChangeOrderNumberFailed"
        errorDescription = "Could not get a number for a change order"
        Return

      Case "1619"
        errorName = "GetNumberingSchemesFailed"
        errorDescription = "Could not get change order numbering schemes"
        Return

      Case "1620"
        errorName = "SetDefaultNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "1621"
        errorName = "ActivateNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "1622"
        errorName = "DeactivateNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "1623"
        errorName = "AddNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "1624"
        errorName = "UpdateNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "1625"
        errorName = "DeleteNumberingSchemeFailed"
        errorDescription = ""
        Return

      Case "1626"
        errorName = "DeleteUserDefinedPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1627"
        errorName = "GetUserDefinedPropertyDefinitionIdsByChangeOrderTypeIdFailed"
        errorDescription = ""
        Return

      Case "1628"
        errorName = "CannotEditItem"
        errorDescription = "Cannot make item on change order editable"
        Return

      Case "1629"
        errorName = "SetChangeOrderItemEditableFailed"
        errorDescription = ""
        Return

      Case "1630"
        errorName = "OwnerMustBeChangeRequestor"
        errorDescription = "The change order creator cannot have change requestor role revoked."
        Return

      Case "1631"
        errorName = "NonChangeRequestorDenied"
        errorDescription = "You must have the Change Requestor role on this change order's routing to perform the operation."
        Return

      Case "1632"
        errorName = "NumberingSchemeIsDefault"
        errorDescription = ""
        Return

      Case "1633"
        errorName = "RestrictionsOccurred"
        errorDescription = "Restrictions have occurred. More information available in SoapException detail."
        Return

      Case "1634"
        errorName = "ItemObsolete"
        errorDescription = "You cannot add obsolete items to a change order"
        Return

      Case "1635"
        errorName = "GetChangeOrderNumberSchemeStartFailed"
        errorDescription = "used as IDS_NUMBERINGSCHEME_GET_STARTNUMBER_FAILED in Change Order world."
        Return

      Case "1636"
        errorName = "GetChangeOrderNumberSchemeStartFailedProviderDoesNotSupport"
        errorDescription = "used as IDS_NUMBERINGSCHEME_GET_STARTNUMBER_PROVIDER_ERROR in Change Order world."
        Return

      Case "1637"
        errorName = "SetChangeOrderNumberSchemeStartFailed"
        errorDescription = "used as IDS_NUMBERINGSCHEME_SET_STARTNUMBER_FAILED in Change Order world."
        Return

      Case "1638"
        errorName = "SetChangeOrderNumberSchemeStartFailedProviderDoesNotSupport"
        errorDescription = "used as IDS_NUMBERINGSCHEME_SET_STARTNUMBER_PROVIDER_ERROR in Change Order world."
        Return

      Case "1639"
        errorName = "SetChangeOrderNumberSchemeStartFailedStartNumberMustBeGreaterThanCurrent"
        errorDescription = "used as IDS_NUMBERINGSCHEME_SET_STARTNUMBER_LESS_ERROR in Change Order world."
        Return

      Case "1640"
        errorName = "GetChangeOrderNumberFailedAutoFieldNumberUsedUp"
        errorDescription = "used as IDS_CHANGEORDER_CREATE_FAILED in Change Order world."
        Return

      Case "1641"
        errorName = "GetRollbackItemLifeCycleStatesInfoFailed"
        errorDescription = "Could not retreive rollback information."
        Return

      Case "1642"
        errorName = "RollbackItemLifeCycleStatesFailed"
        errorDescription = ""
        Return

      Case "1643"
        errorName = "RollbackItemLifeCycleStatesCancelFailed"
        errorDescription = ""
        Return

      Case "1644"
        errorName = "ChangeOrderNotActive"
        errorDescription = ""
        Return

      Case "1645"
        errorName = "ItemNotOnChangeOrder"
        errorDescription = ""
        Return

      Case "1646"
        errorName = "GetUserDefinedPropertyDefinitionIdsByChangeOrderTypeIdFailed"
        errorDescription = "Could not get item related user defined property definitions for change order type."
        Return

      Case "1647"
        errorName = "DeleteChangeOrderFailed"
        errorDescription = ""
        Return

      Case "1648"
        errorName = "NonResponsibleEngineerDenied"
        errorDescription = ""
        Return

      Case "1649"
        errorName = "GetAllPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1652"
        errorName = "AddCustomPropertyDefFailed"
        errorDescription = ""
        Return

      Case "1656"
        errorName = "InappropriateRouting"
        errorDescription = ""
        Return

      Case "1657"
        errorName = "IllegalNullParam"
        errorDescription = ""
        Return

      Case "1664"
        errorName = "GetRequireReviewLifeCycleStateBeforeChangeOrderReviewFailed"
        errorDescription = ""
        Return

      Case "1665"
        errorName = "SetRequireReviewLifeCycleStateBeforeChangeOrderReviewFailed"
        errorDescription = ""
        Return

      Case "1679"
        errorName = "ItemlessChangeOrder"
        errorDescription = ""
        Return

      Case "1688"
        errorName = "CheckoutFileToChangeOrder"
        errorDescription = ""
        Return

      Case "1689"
        errorName = "FileOnAnotherChangeOrder"
        errorDescription = ""
        Return

      Case "1690"
        errorName = "ChangeOrderWithCheckoutFileCannotCloseOrCancel"
        errorDescription = ""
        Return

      Case "1691"
        errorName = "DeleteItemUserDefinedPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "1809"
        errorName = "ReportWriteFailure"
        errorDescription = ""
        Return

      Case "1810"
        errorName = "GenerateReportFailed"
        errorDescription = ""
        Return

      Case "1811"
        errorName = "GetTemplatePropertiesFailed"
        errorDescription = ""
        Return

      Case "1812"
        errorName = "InvalidParentChildInstanceProperty"
        errorDescription = ""
        Return

      Case "1813"
        errorName = "MissingPageReference"
        errorDescription = ""
        Return

      Case "1814"
        errorName = "MissingPageDetailsReference"
        errorDescription = ""
        Return

      Case "1815"
        errorName = "MissingDetailReference"
        errorDescription = ""
        Return

      Case "1816"
        errorName = "MissingCoverPageReference"
        errorDescription = ""
        Return

      Case "1817"
        errorName = "InequableAmountOfColumns"
        errorDescription = ""
        Return

      Case "1818"
        errorName = "InvalidPageSize"
        errorDescription = ""
        Return

      Case "1819"
        errorName = "MissingGroupHeader"
        errorDescription = ""
        Return

      Case "1820"
        errorName = "MissingGroupFooter"
        errorDescription = ""
        Return

      Case "1821"
        errorName = "InvalidData"
        errorDescription = ""
        Return

      Case "1822"
        errorName = "MissingPropertiesReference"
        errorDescription = ""
        Return

      Case "1823"
        errorName = "InvalidAmountOfColumnsInPropsSection"
        errorDescription = ""
        Return

      Case "1824"
        errorName = "PropertyLabelMustBeUnique"
        errorDescription = ""
        Return

      Case "1825"
        errorName = "InvalidPropertyDataType"
        errorDescription = ""
        Return

      Case "1826"
        errorName = "InvalidPropertySource"
        errorDescription = ""
        Return

      Case "1827"
        errorName = "InvalidReportProperty"
        errorDescription = ""
        Return

      Case "1828"
        errorName = "InvalidSystemProperty"
        errorDescription = ""
        Return

      Case "1829"
        errorName = "InvalidGroupDetail"
        errorDescription = ""
        Return

      Case "1830"
        errorName = "CellOutOfRangeError"
        errorDescription = ""
        Return

      Case "1831"
        errorName = "SectionHasTooManyRows"
        errorDescription = ""
        Return

      Case "1832"
        errorName = "InvalidInstanceProperty"
        errorDescription = ""
        Return

      Case "1833"
        errorName = "InvalidCalculatedProperty"
        errorDescription = ""
        Return

      Case "1834"
        errorName = "InvalidPropertyQualifier"
        errorDescription = ""
        Return

      Case "1835"
        errorName = "CircularReference"
        errorDescription = ""
        Return

      Case "1836"
        errorName = "PropertyLabelEmptyError"
        errorDescription = ""
        Return

      Case "2000"
        errorName = "PublishPackageFailed"
        errorDescription = ""
        Return

      Case "2001"
        errorName = "PublishDataAlreadyExists"
        errorDescription = "An attempt to publish new data failed because it would overwrite existing data"
        Return

      Case "2002"
        errorName = "PublishOutOfSyncObject"
        errorDescription = "An attempt to re-publish data failed because it has become out of date."
        Return

      Case "2003"
        errorName = "PublishLinkToSelf"
        errorDescription = ""
        Return

      Case "2010"
        errorName = "WriteLibraryInfoFailed"
        errorDescription = "An error occurred while trying to write LibraryInfo object to library."
        Return

      Case "2011"
        errorName = "ReadLibraryInfoFailed"
        errorDescription = "An error occurred while trying to read LibraryInfo object from library."
        Return

      Case "2012"
        errorName = "LibraryIdNotFound"
        errorDescription = "The specified library ID was not found."
        Return

      Case "2019"
        errorName = "InvalidFamilyAspect"
        errorDescription = "The specified aspect name is either not supported or is being used improperly."
        Return

      Case "2020"
        errorName = "ObjectDataNotFound"
        errorDescription = "An attempt to get or delete the specified object data, or to get its version failed because no such object exists."
        Return

      Case "2021"
        errorName = "AddCategory_ParentNotFound"
        errorDescription = "An attempt to add a child category failed because its parent does not exist."
        Return

      Case "2022"
        errorName = "UpdateCategory_CategoryNotFound"
        errorDescription = ""
        Return

      Case "2023"
        errorName = "AttachLibrary_GeneralFailure"
        errorDescription = "Unused"
        Return

      Case "2024"
        errorName = "AttachLibrary_CheckFileExistence"
        errorDescription = ""
        Return

      Case "2025"
        errorName = "AttachLibrary_DataFileNotFound"
        errorDescription = "Unused"
        Return

      Case "2026"
        errorName = "AttachLibrary_InitializeRolesAndPermissions"
        errorDescription = "Unused"
        Return

      Case "2027"
        errorName = "AttachLibrary_AttachKnowledgeVault"
        errorDescription = ""
        Return

      Case "2028"
        errorName = "AttachLibrary_ReadLibraryInfo"
        errorDescription = "Unused"
        Return

      Case "2029"
        errorName = "AttachLibrary_MissingLibraryInfo"
        errorDescription = "Unused"
        Return

      Case "2030"
        errorName = "AttachLibrary_PrepareKnowledgeVaultMetaData"
        errorDescription = "Unused"
        Return

      Case "2031"
        errorName = "AttachLibrary_WriteKnowledgeVaultMetaData"
        errorDescription = ""
        Return

      Case "2032"
        errorName = "AttachLibrary_UpdateLibraryUsers"
        errorDescription = "Unused"
        Return

      Case "2033"
        errorName = "CreateLibrary_GeneralFailure"
        errorDescription = "Unused"
        Return

      Case "2034"
        errorName = "CreateLibrary_InitializeRolesAndPermissions"
        errorDescription = "Unused"
        Return

      Case "2035"
        errorName = "CreateLibrary_AddKnowledgeVault"
        errorDescription = "Unused"
        Return

      Case "2036"
        errorName = "CreateLibrary_PrepareLibraryInfo"
        errorDescription = "Unused"
        Return

      Case "2037"
        errorName = "CreateLibrary_WriteLibraryInfo"
        errorDescription = ""
        Return

      Case "2038"
        errorName = "CreateLibrary_PrepareKnowledgeVaultMetaData"
        errorDescription = ""
        Return

      Case "2039"
        errorName = "CreateLibrary_WriteKnowledgeVaultMetaData"
        errorDescription = ""
        Return

      Case "2040"
        errorName = "CreateLibrary_UpdateLibraryUsers"
        errorDescription = "Unused"
        Return

      Case "2041"
        errorName = "UpdateLibraryUsers_MissingUsers"
        errorDescription = "Unused"
        Return

      Case "2042"
        errorName = "UpdateLibraryUsers_AddFailed"
        errorDescription = "Unused"
        Return

      Case "2043"
        errorName = "DetachLibrary_DatabaseNotFound"
        errorDescription = "Unused"
        Return

      Case "2044"
        errorName = "TableOfContents_NoLanguageSpecified"
        errorDescription = "A null or empty lang string was passed to GetTableOfContents"
        Return

      Case "2045"
        errorName = "CreateLibrary_AlreadyExists"
        errorDescription = "Unused"
        Return

      Case "2050"
        errorName = "InvalidSchema_NotCompiled"
        errorDescription = ""
        Return

      Case "2051"
        errorName = "InvalidSchema_NoNamespace"
        errorDescription = ""
        Return

      Case "2052"
        errorName = "InvalidSchema_UnsupportedRestriction"
        errorDescription = ""
        Return

      Case "2053"
        errorName = "InvalidSchema_UnsupportedSimpleType"
        errorDescription = ""
        Return

      Case "2054"
        errorName = "InvalidSchema_UnsupportedRestrictionType"
        errorDescription = ""
        Return

      Case "2055"
        errorName = "InvalidSchema_UnsupportedDataType"
        errorDescription = ""
        Return

      Case "2056"
        errorName = "InvalidQuery_MissingRootNode"
        errorDescription = "Search was not called with proper query xml"
        Return

      Case "2057"
        errorName = "InvalidQuery_NoReturnValues"
        errorDescription = "Search did not specify anything to return"
        Return

      Case "2058"
        errorName = "InvalidQuery_MissingFieldSpecifier"
        errorDescription = ""
        Return

      Case "2059"
        errorName = "InvalidQuery_UnsupportedDataType"
        errorDescription = ""
        Return

      Case "2060"
        errorName = "InvalidQuery_MissingReturnProperty"
        errorDescription = "Search did not fully specify a return value"
        Return

      Case "2061"
        errorName = "InvalidQuery_DuplicateReference"
        errorDescription = "Search specified a duplicate reference in a return value"
        Return

      Case "2062"
        errorName = "InvalidQuery_InvalidFieldReference"
        errorDescription = "Search referenced a return value that does not exist"
        Return

      Case "2063"
        errorName = "InvalidQuery_MissingOperator"
        errorDescription = "Search constraint did not specifiy an operator"
        Return

      Case "2064"
        errorName = "InvalidQuery_MissingSearchCriterion"
        errorDescription = "Search constraint did not specify a value"
        Return

      Case "2065"
        errorName = "InvalidQuery_MissingPropertyRelation"
        errorDescription = ""
        Return

      Case "2066"
        errorName = "InvalidQuery_UnsupportedSystemProperty"
        errorDescription = "Search returns or is constrained by a a property that does not exist"
        Return

      Case "2067"
        errorName = "InvalidQuery_InvalidSchemaNamespace"
        errorDescription = ""
        Return

      Case "2068"
        errorName = "InvalidQuery_InvalidProperty"
        errorDescription = ""
        Return

      Case "2069"
        errorName = "InvalidQuery_InvalidRelation"
        errorDescription = ""
        Return

      Case "2070"
        errorName = "Resource_MissingResourceID"
        errorDescription = ""
        Return

      Case "2071"
        errorName = "Resource_StringsNotFound"
        errorDescription = ""
        Return

      Case "2072"
        errorName = "Resource_LocaleNotFound"
        errorDescription = ""
        Return

      Case "2073"
        errorName = "InvalidResource_MissingRootNode"
        errorDescription = ""
        Return

      Case "2074"
        errorName = "InvalidResource_LocaleMismatch"
        errorDescription = ""
        Return

      Case "2075"
        errorName = "InvalidResource_MissingLocale"
        errorDescription = ""
        Return

      Case "2076"
        errorName = "QueryExecutionError"
        errorDescription = "Search resulted in a SQL error"
        Return

      Case "2077"
        errorName = "InternalError"
        errorDescription = ""
        Return

      Case "2078"
        errorName = "InvalidQuery_UnknownCategoryParameter"
        errorDescription = "Search contained an unknown category parameter"
        Return

      Case "2079"
        errorName = "InvalidQuery_InvalidNumberOfValues"
        errorDescription = ""
        Return

      Case "3002"
        errorName = "FailedToFindPropertyDefinition"
        errorDescription = ""
        Return

      Case "3003"
        errorName = "InvalidParameterInput"
        errorDescription = ""
        Return

      Case "3004"
        errorName = "InternalError"
        errorDescription = ""
        Return

      Case "3005"
        errorName = "UnknownEntityClass"
        errorDescription = ""
        Return

      Case "3006"
        errorName = "UnknownEntityClassId"
        errorDescription = ""
        Return

      Case "3007"
        errorName = "UnknownPropertyDefinitionId"
        errorDescription = ""
        Return

      Case "3008"
        errorName = "InvalidPropertyDefDataTypeMapping"
        errorDescription = ""
        Return

      Case "3009"
        errorName = "EntityDataCreationFailed"
        errorDescription = ""
        Return

      Case "3100"
        errorName = "BadLifecycleDefinitionId"
        errorDescription = ""
        Return

      Case "3101"
        errorName = "BadStateId"
        errorDescription = ""
        Return

      Case "3102"
        errorName = "BadTransitionId"
        errorDescription = ""
        Return

      Case "3104"
        errorName = "AddLifeCycleStateTransitionFailed"
        errorDescription = ""
        Return

      Case "3105"
        errorName = "AddLifeCycleStateFailed"
        errorDescription = ""
        Return

      Case "3106"
        errorName = "AddLifeCycleDefinitionFailed"
        errorDescription = ""
        Return

      Case "3107"
        errorName = "AddLifeCycleStateTransitionACLFailed"
        errorDescription = ""
        Return

      Case "3108"
        errorName = "InvalidUserName"
        errorDescription = ""
        Return

      Case "3109"
        errorName = "CannotChangeDefinitionToItself"
        errorDescription = ""
        Return

      Case "3110"
        errorName = "InvalidDefinitionChange"
        errorDescription = ""
        Return

      Case "3111"
        errorName = "InvalidStateTransition"
        errorDescription = ""
        Return

      Case "3115"
        errorName = "DuplicatedStateDisplayName"
        errorDescription = ""
        Return

      Case "3116"
        errorName = "DuplicatedDefinitionDisplayName"
        errorDescription = ""
        Return

      Case "3120"
        errorName = "LifecycleDefinitionAlreadyExists"
        errorDescription = ""
        Return

      Case "3121"
        errorName = "LifecycleStateAlreadyExists"
        errorDescription = ""
        Return

      Case "3122"
        errorName = "LifecycleStateTransitionAlreadyExists"
        errorDescription = ""
        Return

      Case "3123"
        errorName = "RulePropDefDoesNotExist"
        errorDescription = ""
        Return

      Case "3124"
        errorName = "LifecycleDefinitionBeyondMaxLength"
        errorDescription = ""
        Return

      Case "3125"
        errorName = "TransitionSourceStateNotExist"
        errorDescription = ""
        Return

      Case "3126"
        errorName = "TransitionDestinationStateNotExist"
        errorDescription = ""
        Return

      Case "3127"
        errorName = "TransitionCrossLifecycleDefinition"
        errorDescription = ""
        Return

      Case "3300"
        errorName = "RevisionSequenceInUseCannotBeRemoved"
        errorDescription = ""
        Return

      Case "3304"
        errorName = "RevisionSequenceInUseCannotBeUpdated"
        errorDescription = ""
        Return

      Case "3306"
        errorName = "BadRevisionDefinitionId"
        errorDescription = ""
        Return

      Case "3307"
        errorName = "BadRevisionSequenceId"
        errorDescription = ""
        Return

      Case "3308"
        errorName = "RevisionSequenceDuplicateName"
        errorDescription = ""
        Return

      Case "3309"
        errorName = "RevisionDefinitionDuplicateName"
        errorDescription = ""
        Return

      Case "3310"
        errorName = "SeparatorNotValid"
        errorDescription = ""
        Return

      Case "3311"
        errorName = "SeparatorExistInRevisionSequence"
        errorDescription = ""
        Return

      Case "3312"
        errorName = "InvalidLabel"
        errorDescription = ""
        Return

      Case "3313"
        errorName = "RevisionLabelIsNullOrEmpty"
        errorDescription = ""
        Return

      Case "3314"
        errorName = "RevisionLabelBeyondMaxLength"
        errorDescription = ""
        Return

      Case "3315"
        errorName = "RevisionLabelDuplicate"
        errorDescription = ""
        Return

      Case "3316"
        errorName = "BadStartLabel"
        errorDescription = ""
        Return

      Case "3321"
        errorName = "InvalidDefinitionChange"
        errorDescription = ""
        Return

      Case "3322"
        errorName = "InvalidRevisionNumber"
        errorDescription = ""
        Return

      Case "3330"
        errorName = "GetRevisionDefinitionIdsByMasterIdsFailed"
        errorDescription = ""
        Return

      Case "3331"
        errorName = "GetNextRevisionNumbersByMasterIdsFailed"
        errorDescription = ""
        Return

      Case "3333"
        errorName = "SetRevisionNumberFailed"
        errorDescription = ""
        Return

      Case "3334"
        errorName = "SetRevisionNumbersFailed"
        errorDescription = ""
        Return

      Case "3335"
        errorName = "SetRevisionDefinitionAndNumbersFailed"
        errorDescription = ""
        Return

      Case "3336"
        errorName = "GetAllRevisionDefinitionInfoFailed"
        errorDescription = ""
        Return

      Case "3337"
        errorName = "GetRevisionDefinitionInfoByIdsFailed"
        errorDescription = ""
        Return

      Case "3338"
        errorName = "AddRevisionDefinitionFailed"
        errorDescription = ""
        Return

      Case "3339"
        errorName = "UpdateRevisionDefinitionFailed"
        errorDescription = ""
        Return

      Case "3340"
        errorName = "DeleteRevisionDefinitionFailed"
        errorDescription = ""
        Return

      Case "3341"
        errorName = "AddRevisionSequenceFailed"
        errorDescription = ""
        Return

      Case "3342"
        errorName = "UpdateRevisionSequenceFailed"
        errorDescription = ""
        Return

      Case "3343"
        errorName = "DeleteRevisionSequenceFailed"
        errorDescription = ""
        Return

      Case "3344"
        errorName = "SystemRevisionSequenceNotExist"
        errorDescription = ""
        Return

      Case "3345"
        errorName = "ImportRevisionDefinitionFailed"
        errorDescription = ""
        Return

      Case "3346"
        errorName = "RevisionDefinitionAlreadyExists"
        errorDescription = ""
        Return

      Case "3500"
        errorName = "BehaviorClassDoesNotSupportRules"
        errorDescription = ""
        Return

      Case "3501"
        errorName = "UnknownBehaviorClass"
        errorDescription = ""
        Return

      Case "3502"
        errorName = "UnknownBehaviorClassId"
        errorDescription = ""
        Return

      Case "3503"
        errorName = "FailureToGetBehaviorType"
        errorDescription = ""
        Return

      Case "3504"
        errorName = "FailureToCreateBehaviorClassInstance"
        errorDescription = ""
        Return

      Case "3505"
        errorName = "FailureToGetPropertySetId"
        errorDescription = ""
        Return

      Case "3506"
        errorName = "BehaviorClassFailedToProvideBehaviorView"
        errorDescription = ""
        Return

      Case "3507"
        errorName = "UnknownBehavior"
        errorDescription = ""
        Return

      Case "3508"
        errorName = "BehaviorCannotBeAssignedAsDefault"
        errorDescription = ""
        Return

      Case "3509"
        errorName = "BehaviorAlreadyAssocToEntityClass"
        errorDescription = ""
        Return

      Case "3510"
        errorName = "UnknownEntityAssocTable"
        errorDescription = ""
        Return

      Case "3511"
        errorName = "InvalidBehaviorsForAssocToEntityClass"
        errorDescription = ""
        Return

      Case "3512"
        errorName = "TooManyDefaultBehavoirsAssigned"
        errorDescription = ""
        Return

      Case "3513"
        errorName = "ZeroDefaultBehaviorsNoAllowed"
        errorDescription = ""
        Return

      Case "3514"
        errorName = "UnknownBehaviorId"
        errorDescription = ""
        Return

      Case "3515"
        errorName = "CannotDeleteBehavior_InUseByEntity"
        errorDescription = ""
        Return

      Case "3516"
        errorName = "CannotDeleteBehavior_InUseByAnotherBehavior"
        errorDescription = ""
        Return

      Case "3517"
        errorName = "CannotDeleteBehavior_ItIsAnEntityClassDefault"
        errorDescription = ""
        Return

      Case "3518"
        errorName = "CannotDeleteBehavior_ReasonUnknown"
        errorDescription = ""
        Return

      Case "3519"
        errorName = "UnknownBehaviorIdOrIsNotAssocToEntityClass"
        errorDescription = ""
        Return

      Case "3700"
        errorName = "UnknownCategoryId"
        errorDescription = ""
        Return

      Case "3701"
        errorName = "CategoryToCopyNotAssocToEntityClass"
        errorDescription = ""
        Return

      Case "3702"
        errorName = "FailureToFindCategoryRuleSet"
        errorDescription = ""
        Return

      Case "3703"
        errorName = "FailureToFindCategoryForEntity"
        errorDescription = ""
        Return

      Case "3704"
        errorName = "CategoryIdNotAssocToEntityClass"
        errorDescription = ""
        Return

      Case "3705"
        errorName = "CategoryAlreadyExists"
        errorDescription = ""
        Return

      Case "3706"
        errorName = "UnknownCategory"
        errorDescription = ""
        Return

      Case "3707"
        errorName = "EntityClassDoesNotSupportCategoryRules"
        errorDescription = ""
        Return

      Case "3708"
        errorName = "EntityIdDoesNotMatchEntityClass"
        errorDescription = ""
        Return

      Case "3709"
        errorName = "CategoryCfgCopyFailed"
        errorDescription = ""
        Return

      Case "3710"
        errorName = "CategoryUpdateFailed"
        errorDescription = ""
        Return

      Case "3900"
        errorName = "UpdatePropertyDefMappingsFailed"
        errorDescription = ""
        Return

      Case "3901"
        errorName = "DuplicateMapping"
        errorDescription = ""
        Return

      Case "3902"
        errorName = "NotUserDefinedPropertyDef"
        errorDescription = ""
        Return

      Case "3903"
        errorName = "SelfMapping"
        errorDescription = ""
        Return

      Case "3904"
        errorName = "NotFileIterationPropertyDef"
        errorDescription = ""
        Return

      Case "3905"
        errorName = "NotIndexedFileProperty"
        errorDescription = ""
        Return

      Case "3906"
        errorName = "GetUserDefinedPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "3907"
        errorName = "UpdateUserDefinedPropertyDefFailed"
        errorDescription = ""
        Return

      Case "3908"
        errorName = "UpdatePropertyValuesFailed"
        errorDescription = ""
        Return

      Case "3909"
        errorName = "GetPropertyDefDeleteRestrictionsFailed"
        errorDescription = ""
        Return

      Case "3910"
        errorName = "DeletePropertyDefsFailed"
        errorDescription = ""
        Return

      Case "3911"
        errorName = "AddOrRemovePropertyFailed"
        errorDescription = ""
        Return

      Case "3912"
        errorName = "AddPropertyConstraintsFailed"
        errorDescription = ""
        Return

      Case "3913"
        errorName = "UpdatePropertyConstraintsFailed"
        errorDescription = ""
        Return

      Case "3914"
        errorName = "DeletePropertyConstraintsFailed"
        errorDescription = ""
        Return

      Case "3915"
        errorName = "GetPropertyConstraintFailuresFailed"
        errorDescription = ""
        Return

      Case "3916"
        errorName = "CreateUserDefinedPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "3917"
        errorName = "InvalidOperationOnSpecificConstraintType"
        errorDescription = ""
        Return

      Case "3918"
        errorName = "DuplicateDisplayName"
        errorDescription = ""
        Return

      Case "3919"
        errorName = "GetPropertyDefinitionsFailed"
        errorDescription = ""
        Return

      Case "3920"
        errorName = "EntityClassIdDoesNotExist"
        errorDescription = ""
        Return

      Case "3921"
        errorName = "UserDefinedPropertyDefIdDoesNotExist"
        errorDescription = ""
        Return

      Case "3922"
        errorName = "UserDefinedPropertyDefIdHasAnAssignedEntityClass"
        errorDescription = ""
        Return

      Case "3923"
        errorName = "DisplayNameCollision"
        errorDescription = ""
        Return

      Case "3924"
        errorName = "InvalidMappingTarget_TOPropertyIsReadOnly"
        errorDescription = "Certain Inventor file properties are read-only.  Trying to write to them will throw exceptions (from Inventor APIs), so we should not allow mappings TO them. "
        Return

      Case "3925"
        errorName = "InvalidMapping_DifferentDatatypes"
        errorDescription = ""
        Return

      Case "3926"
        errorName = "CheckCompliancesFailed"
        errorDescription = ""
        Return

      Case "3929"
        errorName = "InvalidMappingTarget_FROMProperty"
        errorDescription = "Not all property definitions can be used as from mapping targets."
        Return

      Case "3930"
        errorName = "InvalidMappingTarget_TOProperty"
        errorDescription = "Not all property definitions can be used as to mapping targets."
        Return

      Case "3931"
        errorName = "NonCompliantConstraintWithDefaultValue"
        errorDescription = "New constraint can't be added or new default vaule can't be updated if the default value is not compliant with it."
        Return

      Case "3932"
        errorName = "UpdatedValueNotIncludedInList"
        errorDescription = "The updated property value must be one of the value list for property definition of list type."
        Return

      Case "3933"
        errorName = "UpdatePropertiesFailed"
        errorDescription = ""
        Return

      Case "4000"
        errorName = "InputConfigSectionCanNotBeNull"
        errorDescription = ""
        Return

      Case "4001"
        errorName = "InvalidPropertySetGUID"
        errorDescription = ""
        Return

      Case "4002"
        errorName = "UDPDefintionNameCanNotBeEmpty"
        errorDescription = ""
        Return

      Case "4003"
        errorName = "UserDefinedPropertyDefaultValueRequired"
        errorDescription = ""
        Return

      Case "4004"
        errorName = "ValueExpressionNotParseable"
        errorDescription = ""
        Return

      Case "4400"
        errorName = "NoSitesInWorkgroupToRequestOwnership"
        errorDescription = ""
        Return

      Case "4401"
        errorName = "LeaseNotUp"
        errorDescription = ""
        Return

      Case "4402"
        errorName = "ErrorsWhileTransferringOwnership"
        errorDescription = ""
        Return

      Case "4403"
        errorName = "UnknownWorkgroup"
        errorDescription = ""
        Return

      Case "4405"
        errorName = "WorkgroupNotEntityOwner"
        errorDescription = ""
        Return

      Case "4407"
        errorName = "WorkgroupNotAdminOwner"
        errorDescription = ""
        Return

      Case "4408"
        errorName = "WorkgroupIsPublisher"
        errorDescription = ""
        Return

      Case "4410"
        errorName = "WorkgroupExists"
        errorDescription = ""
        Return

      Case "4411"
        errorName = "NotFullSQL"
        errorDescription = ""
        Return

      Case "4412"
        errorName = "ConfigurationError"
        errorDescription = ""
        Return

      Case "4413"
        errorName = "ReplicationEnabled"
        errorDescription = ""
        Return

      Case "4414"
        errorName = "SubscribingWorkgroups"
        errorDescription = ""
        Return

      Case "4415"
        errorName = "SubscriberCleanupError"
        errorDescription = ""
        Return

      Case "4416"
        errorName = "ReplicationNotEnabled"
        errorDescription = ""
        Return

      Case "4417"
        errorName = "SubscriptionNotActive"
        errorDescription = ""
        Return

      Case "4418"
        errorName = "ServerConnectionFailureOrChangesPending"
        errorDescription = ""
        Return

      Case "4419"
        errorName = "DatabaseReplicationEnabled"
        errorDescription = ""
        Return

      Case "4420"
        errorName = "WorkgroupIsSubscriber"
        errorDescription = ""
        Return

      Case "4421"
        errorName = "SubscriberSqlVersionMismatch"
        errorDescription = ""
        Return

      Case "4423"
        errorName = "OtherEntityInGroupNotTransferrable"
        errorDescription = ""
        Return

      Case "4424"
        errorName = "DatabaseNotReplicated"
        errorDescription = ""
        Return

      Case "4425"
        errorName = "DatabaseInvalidCharacters"
        errorDescription = ""
        Return

      Case "4600"
        errorName = "InvalidSystemName"
        errorDescription = "Systems names set through the API must be a GUID, ""D"" format."
        Return

      Case "4601"
        errorName = "DatabaseTakeOnlineFailed"
        errorDescription = ""
        Return

      Case "4602"
        errorName = "InvalidSearchOperation"
        errorDescription = ""
        Return

      Case "8000"
        errorName = "TicketInvalid"
        errorDescription = ""
        Return

      Case "8001"
        errorName = "CannotSyncConfiguration"
        errorDescription = ""
        Return

      Case "8002"
        errorName = "FileMissingFromStore"
        errorDescription = ""
        Return

      Case "8003"
        errorName = "DataManagerNotConfigured"
        errorDescription = ""
        Return

      Case "8004"
        errorName = "SiteSigninError"
        errorDescription = ""
        Return

      Case "8005"
        errorName = "WebServiceError"
        errorDescription = ""
        Return

      Case "8006"
        errorName = "UnregisteredExternalFileUploader"
        errorDescription = ""
        Return

      Case "8007"
        errorName = "ExternalFileUploaderNotInstalled"
        errorDescription = ""
        Return

      Case "8008"
        errorName = "UploadExternalFileFailed"
        errorDescription = ""
        Return
    End Select
  End Sub

  Private Shared Sub WriteCodeLine(ByVal codeline As String)
    File.AppendAllText("C:\Code.txt", codeline + vbCr & vbLf)
  End Sub
End Class

