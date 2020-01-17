DECLARE @RoutineId int = 100000;
DECLARE @RoutineTitle NVARCHAR(MAX) = N'فرآیند ترفیع اعضای هیئت علمی';
DECLARE @RoutineTableName VARCHAR(MAX) = 'Promotion';
DECLARE @RoutinePkColumnName VARCHAR(MAX) = 'Id';

-- delete old datas
DELETE [Routine2Role] WHERE [RoutineId] = @RoutineId
DELETE [Routine2Step] WHERE [RoutineId] = @RoutineId
DELETE [Routine2Action] WHERE [RoutineId] = @RoutineId
DELETE [Routine2Autodash] WHERE [RoutineId] = @RoutineId


-- Create Routine
if exists (select * from [Routine2] with (updlock,serializable) where [Id] = @RoutineId)
begin
   UPDATE [Routine2] set
		[Title] = @RoutineTitle
	  , [TableName] = @RoutineTableName
	  , [PkColumnName] = @RoutinePkColumnName
   WHERE [Id] = @RoutineId
end
else
begin
    SET IDENTITY_INSERT [Routine2] ON
    INSERT INTO [Routine2] (
          [Id]
        , [Title]
        , [TableName]
        , [PkColumnName]
    )

    VALUES (
          @RoutineId
        , @RoutineTitle
        , @RoutineTableName
        , @RoutinePkColumnName
    )
    SET IDENTITY_INSERT [Routine2] OFF
end



-- Create RoutineRoles

INSERT INTO [Routine2Role] (
	[RoutineId],    [SortOrder],       [DashboardEnum],                   [Title],                             [StepsJson]) VALUES
	(@RoutineId,        '1',            'Faculty',                        N'اعضای هیئت علمی',            		'["100"]')
  ,	(@RoutineId,        '2',            'RelagiousCommittee',             N'رئیس کمیته معارف استان',		    '["200"]')

  , (@RoutineId,        '3',            'ExpertChairman',                 N'کارشناس بررسی مجوز',               '["300"]')
  , (@RoutineId,        '4',            'ManagerChairman',                N'رئیس اداره جذب',                   '["300"]')

  , (@RoutineId,        '5',            'SpecialCommitteeManager',        N'رئیس کمیته موارد خاص',             '["400"]')
  , (@RoutineId,        '6',            'SpecialCommitteeMember',         N'اعضا کمیسیون کمیته موارد خاص',    '["400"]')
 
  , (@RoutineId,        '7',            'ChairmanManager',                N'مدیر جذب',                          '["500"]')
  , (@RoutineId,        '8',            'AssistantSetad',                 N'معاون آموزش ستاد',                 '["600"]')
  , (@RoutineId,        '9',            'CancelLicenseChoiceVote',        N'بررسی توسط گزینش',                 '["700"]')



-- Create RoutineSteps
INSERT INTO [Routine2Step] (
	  [RoutineId],        [Step],         [F1],        [F2],        [F3],        [F4],      [F5],      [F6],     [F7],      [Title] )    VALUES
      (@RoutineId,         100,           200,         NULL,        NULL,        NULL,      NULL,      NULL,     NULL,      N'درخواست لغو مجوز توسط کارشناس کمیته استان')
	 ,(@RoutineId,         200,           300,         NULL,        210,         100,       NULL,      NULL,     NULL,      N'بررسی درخواست توسط رئیس کمیته معارف استان')
	 ,(@RoutineId,         300,           400,         NULL,        NULL,        100,       NULL,      NULL,     NULL,      N'بررسی درخواست توسط اداره جذب')
	 ,(@RoutineId,         400,           500,         NULL,        NULL ,       NULL,      NULL,      NULL,     NULL,      N'بررسی درخواست توسط رئیس کمیته موارد خاص')
	 ,(@RoutineId,         500,           600,         700,         210,         400,       710,       NULL,     NULL,      N'بررسی درخواست توسط مدیریت جذب')
	 ,(@RoutineId,         600,           220,         700,         210,         NULL,      NULL,      NULL,     NULL,      N'بررسی درخواست توسط معاون آموزش ستاد')
	 ,(@RoutineId,         700,           NULL,        NULL,        NULL,        NULL,      NULL,      NULL,     NULL,      N'در انتظار بررسی توسط گزینش ')
	 ,(@RoutineId,         710,           NULL,        NULL,        NULL,        NULL,      NULL,      NULL,     NULL,      N'در انتظار بررسی توسط سنجش علمی ')
	 ,(@RoutineId,         220,           NULL,        NULL,        NULL,        NULL,      NULL,      NULL,     NULL,      N'تایید نهایی')
	 ,(@RoutineId,         210,           NULL,        NULL,        NULL,        NULL,      NULL,      NULL,     NULL,      N'رد')
	 ,(@RoutineId,         410,           NULL,        NULL,        NULL,        NULL,      NULL,      NULL,     NULL,      N'رد')
;								        																	  
						
						
-- Create Actions Information
INSERT INTO [Routine2Action] (
       [RoutineId],   [Step],      [Action], [IsDescriptionRequired],  [IsDescriptionMultiline], [ShouldHideDescription] ,  [Color], [Icon],           [Title]) VALUES
       (@RoutineId,    100,         'F1',               0,                    0,                           0,               'info',  'play',		  N'ارسال')  
     , (@RoutineId,    200,         'F1',               0,                    0,                           0,               'info',  'play',		  N'ارسال')  
     , (@RoutineId,    600,         'F1',               0,                    0,                           0,               'info',  'play',		  N'ارسال')  
     , (@RoutineId,    600,         'F3',               0,                    0,                           0,               'danger','close-circle',  N'رد')  
     , (@RoutineId,    200,         'F3',               0,                    0,                           0,               'danger','close-circle',  N'رد')  
     , (@RoutineId,    500,         'F3',               0,                    0,                           0,               'danger','close-circle',  N'رد')  
     , (@RoutineId,    300,         'F1',               0,                    0,                           0,               'info',  'play',		  N'ارسال')  
     , (@RoutineId,    300,         'F4',               0,                    0,                           0,               'warning','attention',  N'نیاز به اصلاحات')  
     , (@RoutineId,    400,         'F1',               0,                    0,                           0,               'info',  'play',          N'ارسال')  
     , (@RoutineId,    200,         'F4',               0,                    0,                           0,               'warning','attention',  N'نیاز به اصلاحات')  
     , (@RoutineId,    500,         'F4',               0,                    0,                           0,               'warning','attention',  N'نیاز به اصلاحات')  
     , (@RoutineId,    500,         'F1',               0,                    0,                           0,               'info',  'play',		  N'ارسال')  
     , (@RoutineId,    500,         'F2',               0,                    0,                           0,               'success',         'check',				  N'تایید')  
     , (@RoutineId,    600,         'F2',               0,                    0,                           0,               'success',         'check',				  N'تایید')  
    


SELECT * FROM Routine2 WHERE Id = @RoutineId
SELECT * FROM Routine2Role WHERE RoutineId = @RoutineId
SELECT * FROM Routine2Step WHERE RoutineId = @RoutineId
SELECT * FROM Routine2Action WHERE RoutineId = @RoutineId
SELECT * FROM Routine2Autodash WHERE RoutineId = @RoutineId