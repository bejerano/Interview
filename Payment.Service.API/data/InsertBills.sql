-- Add the Bill status
MERGE INTO [PaymentDb].[billing].[BillStatus] AS Target
USING (
    VALUES 
        (1, 'Paid'),
        (2, 'Overdue'),
        (3, 'Partially_Paid'),
        (4, 'Unpaid')
) AS Source (ID, Name)
ON Target.ID = Source.ID
WHEN NOT MATCHED THEN
    INSERT (ID, Name)
    VALUES (Source.ID, Source.Name);
         
 -- Bills

SET IDENTITY_INSERT [PaymentDb].[billing].[Bills]  ON

MERGE INTO [PaymentDb].[billing].[Bills] AS Target
USING (
    VALUES
        (NEWID(),CONVERT(datetime, '10/07/2023', 101), '123456781', 100.00, 50.00, 'Comcast', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2023', 101), '123456782', 100.00, 0.00, 'AT&T', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2023', 101), '123456783', 100.00, 10.00, 'Georgia Power', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/08/2023', 101), '123456784', 100.00, 15.00, 'Georgia Natural Gas', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/010/2023',101), '12345678', 100.00, 100.00, 'Verizon', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2023', 101), '1234567855', 100.00, 100.00, 'Credit Card', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '123456', 100.00, 100.00, 'Mortgage', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '123789', 100.00, 100.00, 'Car Payment', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '12456789', 100.00, 200.00, 'Student Loan', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '1289', 100.00, 100.00, 'Personal Loan', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '12', 100.00, 50.00, 'Comcast', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '123', 100.00, 0.00, 'AT&T', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '12345', 100.00, 10.00, 'Georgia Power', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '6784', 100.00, 15.00, 'Georgia Natural Gas', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '45678', 100.00, 100.00, 'Verizon', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '7855', 100.00, 100.00, 'Credit Card', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '123456', 100.00, 100.00, 'Mortgage', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '123789', 1000.00, 100.00, 'Car Payment', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '12456789', 10450.00, 200.00, 'Student Loan', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/11/2023', 101), '1289', 100.00, 100.00, 'Personal Loan', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2024', 101), '16781', 100.00, 50.00, 'Comcast', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/12/2023', 101), '12342', 100.00, 0.00, 'AT&T', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/12/2023', 101), '1783', 1020.00, 10.00, 'Georgia Power', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/12/2023', 101), '1784', 100.00, 15.00, 'Georgia Natural Gas', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/12/2023', 101), '178', 100.00, 100.00, 'Verizon', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/12/2023', 101), '134855', 100.00, 100.00, 'Credit Card', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/12/2023', 101), '12456', 1030.00, 500.00, 'Mortgage', 'Lucas', GETDATE(), 'Lucas', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/12/2023', 101), '123789', 100.00, 100.00, 'Car Payment', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/12/2023', 101), '12459', 100.00, 200.00, 'Student Loan', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/12/2023', 101), '1289', 1300.00, 100.00, 'Personal Loan', 'Lucas', GETDATE(), 'Lucas', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2024', 101), '123477', 100.00, 50.00, 'Comcast', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2025', 101), '123488', 10330.00, 0.00, 'AT&T', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2025', 101), '1234599', 100.00, 10.00, 'Georgia Power', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2025', 101), '1234991', 100.00, 15.00, 'Georgia Natural Gas', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2025', 101), '12343334', 100.00, 100.00, 'Verizon', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2025', 101), '1666655', 100.00, 100.00, 'Credit Card', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2025', 101), '1545', 100.00, 100.00, 'Mortgage', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2025', 101), '12344', 300.00, 300.00, 'Car Payment', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2025', 101), '123339', 100.00, 200.00, 'Student Loan', 'Michael', GETDATE(), 'Michael', GETDATE()),
        (NEWID(),CONVERT(datetime, '10/07/2025', 101), '111', 10700.00, 1600.00, 'Personal Loan', 'Michael', GETDATE(), 'Michael', GETDATE())
) AS Source (Id, DueDate, Identifier, TotalDue, PreviousBalance, Vendor, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn)
ON Target.Identifier = Source.Identifier
WHEN MATCHED THEN
    UPDATE SET
        Target.DueDate = Source.DueDate,
        Target.TotalDue = Source.TotalDue,
        Target.PreviousBalance = Source.PreviousBalance,
        Target.Vendor = Source.Vendor,
        Target.CreatedBy = Source.CreatedBy,
        Target.CreatedOn = Source.CreatedOn,
        Target.ModifiedBy = Source.ModifiedBy,
        Target.ModifiedOn = Source.ModifiedOn,
        Target._billStatusId = 
            CASE 
                WHEN Source.PreviousBalance = 0 THEN 1 -- Paid
                WHEN Source.PreviousBalance > 0 AND Source.PreviousBalance < Source.TotalDue THEN 3 -- Partially Paid
                WHEN Source.PreviousBalance = Source.TotalDue THEN 4 -- Unpaid
                WHEN CONVERT(DATE, Source.DueDate, 101) < CONVERT(DATE, GETDATE(), 101) THEN 2 -- Overdue
                ELSE 4 -- Default value for unspecified status
            END
WHEN NOT MATCHED THEN
    INSERT (Id, DueDate, Identifier, TotalDue, PreviousBalance, Vendor, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, _billStatusId)
    VALUES (Source.Id, Source.DueDate, Source.Identifier, Source.TotalDue, Source.PreviousBalance, Source.Vendor, Source.CreatedBy, Source.CreatedOn, Source.ModifiedBy, Source.ModifiedOn,
    CASE 
        WHEN Source.PreviousBalance = 0 THEN 1 -- Paid
        WHEN Source.PreviousBalance > 0 AND Source.PreviousBalance < Source.TotalDue THEN 3 -- Partially Paid
        WHEN Source.PreviousBalance = Source.TotalDue THEN 4 -- Unpaid
        WHEN CONVERT(DATE, Source.DueDate, 101) < CONVERT(DATE, GETDATE(), 101) THEN 2 -- Overdue
        ELSE 4 -- Default value for unspecified status
    END);




SET IDENTITY_INSERT [PaymentDb].[billing].[Bills]  OFF

-- Payments

MERGE INTO [PaymentDb].[billing].[Payments] AS Target
USING (
    SELECT B.[Id] AS BillId, B.[PreviousBalance] AS Amount, P.[BillId1] AS PaymentBillId
    FROM [PaymentDb].[billing].[Bills] AS B
    LEFT JOIN [PaymentDb].[billing].[Payments] AS P ON B.[Id] = P.[BillId1] -- Join with Payments to check duplicates
    WHERE B.[_billStatusId] = 3 -- Partially Paid
) AS Source (BillId, Amount, PaymentBillId)
ON Target.[BillId1] = Source.PaymentBillId AND Target.[Amount] = Source.Amount
WHEN NOT MATCHED THEN
    INSERT (Id, BillId, Amount, DebitDate, Method, Status, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn)
    VALUES (NEWID(), Source.BillId, Source.Amount, GETDATE(), 1, 'Paid', 'Michael', GETDATE(), 'Michael', GETDATE());
