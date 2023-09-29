SET IDENTITY_INSERT [PaymentDb].[billing].[Bills]  ON

INSERT INTO [PaymentDb].[billing].[Bills] 
(Id, DueDate, Identifier, TotalDue, PreviousBalance, Vendor, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn)
VALUES
    (NEWID(),'10/07/2023', '123456781', 100.00, 50.00, 'Comcast', 'Michael', GETDATE(), 'Michael', GETDATE()),
    (NEWID(),'10/07/2023', '123456782', 100.00, 0.00, 'AT&T', 'Michael', GETDATE(), 'Michael', GETDATE()),
    (NEWID(),'10/07/2023', '123456783', 100.00, 10.00, 'Georgia Power', 'Michael', GETDATE(), 'Michael', GETDATE()),
    (NEWID(),'10/07/2023', '123456784', 100.00, 15.00, 'Georgia Natural Gas', 'Michael', GETDATE(), 'Michael', GETDATE()),
    (NEWID(),'10/07/2023', '12345678', 100.00, 100.00, 'Verizon', 'Michael', GETDATE(), 'Michael', GETDATE()),
    (NEWID(),'10/07/2023', '1234567855', 100.00, 100.00, 'Credit Card', 'Michael', GETDATE(), 'Michael', GETDATE()),
    (NEWID(),'10/07/2023', '123456', 100.00, 100.00, 'Mortgage', 'Michael', GETDATE(), 'Michael', GETDATE()),
    (NEWID(),'10/07/2023', '123789', 100.00, 100.00, 'Car Payment', 'Michael', GETDATE(), 'Michael', GETDATE()),
    (NEWID(),'10/07/2023', '12456789', 100.00, 200.00, 'Student Loan', 'Michael', GETDATE(), 'Michael', GETDATE()),
    (NEWID(),'10/07/2023', '1289', 100.00, 100.00, 'Personal Loan', 'Michael', GETDATE(), 'Michael', GETDATE())

SET IDENTITY_INSERT [PaymentDb].[billing].[Bills]  OFF