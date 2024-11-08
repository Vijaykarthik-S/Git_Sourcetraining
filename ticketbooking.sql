
create table Users(
	UserId int identity(1,1) primary key,
	UserName varchar(50),
	PhoneNumber varchar(20),
	Gender varchar(10),
	Email varchar(40),
	Address VARCHAR(255),
	Role VARCHAR(50), -- 'User', 'Admin', 'Operator'
	DateCreated DATETIME DEFAULT CURRENT_TIMESTAMP
)
create table Routes (
    RouteId INT identity(1,1) primary key,
    BusRoute VARCHAR(255), 
    BusId INT,
    DepartureTime DATETIME,
    ArrivalTime DATETIME
);

create table Buses(
	BusId int identity(1,1) primary key,
	BusName varchar(50),
	Bustype varchar(50),
	Amenities varchar(255),
	NumberofSeats int
)


create table Bookings(
	BookingId int identity(1,1) primary key,
	UserId int,
	RouteId int,
	NumberofSeats int,
	TotalPrice DECIMAL(10, 2),
    BookingDate DATETIME DEFAULT CURRENT_TIMESTAMP,
	 FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (RouteId) REFERENCES Routes(RouteId)
)

create table BusOperator(
	OperatorId int identity(1,1) primary key,
	OperatorName varchar(50),
	OperatorPhone varchar(11),
	DateCreated DATETIME DEFAULT CURRENT_TIMESTAMP,
	BusID int foreign key references Buses(BusId)

)

create table Payments (
    Id int identity(1,1) primary key,
    BookingId INT,
    PaymentAmount DECIMAL(10, 2),
    PaymentDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status VARCHAR(50), -- 'Pending', 'Completed'
    FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
);


-- Insert data into Users with Indian names for User, Admin, and Operator roles
INSERT INTO Users (UserName, Email, Gender, PhoneNumber, Address, Role)
VALUES 
    ('Amit Verma', 'amitverma@example.com', 'Male', '9876543210', 'Sector 15, Gurgaon', 'User'),
    ('Priya Sharma', 'priyasharma@example.com','Feale', '8765432109', 'JP Nagar, Bengaluru', 'User'),
    ('Suresh Reddy', 'sureshreddy@example.com','Male', '7654321098', 'Banjara Hills, Hyderabad', 'User'),
    ('Ritika Malhotra', 'ritikamalhotra@example.com','Female', '6543210987', 'Powai, Mumbai', 'User'),
    ('Vikram Patel', 'vikrampatel@example.com','Male', '5432109876', 'Ellis Bridge, Ahmedabad', 'User'),
    ('Meera Iyer', 'meeraiyer@example.com','Female', '4321098765', 'MG Road, Chennai', 'Admin'),
    ('Rajiv Nair', 'rajivnair@example.com','Male', '3210987654', 'Ernakulam, Kochi', 'Admin'),
    ('Ankita Das', 'ankitads@example.com', 'Female','2109876543', 'Salt Lake, Kolkata', 'Admin'),
    ('Kiran Jain', 'kiranjain@example.com','Male', '1098765432', 'Lajpat Nagar, Delhi', 'Operator'),
    ('Arjun Singh', 'arjunsingh@example.com','Male', '9876501234', 'Park Street, Kolkata', 'Operator');

-- Insert data into Routes with Indian routes and timings
INSERT INTO Routes (BusRoute, BusId, DepartureTime, ArrivalTime)
VALUES 
    ('Chennai to Bangalore', 1, '2024-11-10 06:00:00', '2024-11-10 12:00:00'),
    ('Delhi to Jaipur', 2, '2024-11-10 08:00:00', '2024-11-10 14:00:00'),
    ('Mumbai to Pune', 3, '2024-11-10 07:30:00', '2024-11-10 11:00:00'),
    ('Ahmedabad to Surat', 4, '2024-11-10 05:00:00', '2024-11-10 09:00:00'),
    ('Hyderabad to Vijayawada', 5, '2024-11-10 08:30:00', '2024-11-10 13:30:00'),
    ('Lucknow to Kanpur', 6, '2024-11-10 07:00:00', '2024-11-10 09:00:00'),
    ('Bangalore to Mysore', 7, '2024-11-10 09:00:00', '2024-11-10 12:00:00'),
    ('Patna to Gaya', 8, '2024-11-10 10:00:00', '2024-11-10 12:30:00'),
    ('Kolkata to Digha', 9, '2024-11-10 06:30:00', '2024-11-10 10:30:00'),
    ('Chandigarh to Amritsar', 10, '2024-11-10 08:00:00', '2024-11-10 13:00:00');

-- Insert data into BusOperators with unique names
INSERT INTO BusOperator (OperatorName,  OperatorPhone)
VALUES 
    ('Redline Travels','8765432101'),
    ('Southern Express', '7654321012'),
    ('North Star Bus Services', '6543210123'),
    ('Eastern Shuttle',  '5432101234'),
    ('Royal Indian Tours', '4321012345'),
    ('Metro Transport', '3210123456'),
    ('FastTrack Buses',  '2101234567'),
    ('Green Line Services',  '1092345678'),
    ('Tranzit Buses',  '9083456789'),
    ('Golden Routes',  '8074567890');

-- Insert data into Buses with different BusName and BusType
INSERT INTO Buses (BusName, BusType, NumberOfSeats, Amenities)
VALUES 
    ('City Rider', 'Non-AC Seater', 40, 'Water bottle'),
    ('Royal Sleeper', 'AC Sleeper', 32, 'Water bottle, AC, Charging points'),
    ('Metro Cruiser', 'AC Seater', 45, 'Charging points, Wi-Fi'),
    ('Night Express', 'Non-AC Sleeper', 50, 'Blanket, Pillow'),
    ('Sunshine', 'AC Seater', 48, 'Water bottle, AC'),
    ('Northern Breeze', 'AC Sleeper', 35, 'Wi-Fi, Charging points'),
    ('Silver Line', 'Non-AC Seater', 30, 'Water bottle'),
    ('Blue Star', 'AC Seater', 60, 'AC, Wi-Fi, Charging points'),
    ('Traveler X', 'Non-AC Sleeper', 52, 'Pillow, Blanket'),
    ('RapidX', 'AC Sleeper', 45, 'Water bottle, AC, Wi-Fi');

-- Insert data into Bookings with unique entries
INSERT INTO Bookings (UserId, RouteId, NumberOfSeats, TotalPrice)
VALUES 
    (1, 1, 2, 1200.00),
    (2, 2, 1, 800.00),
    (3, 3, 3, 1500.00),
    (4, 4, 2, 700.00),
    (5, 5, 1, 600.00),
    (6, 6, 4, 1600.00),
    (7, 7, 2, 900.00),
    (8, 8, 1, 550.00),
    (9, 9, 2, 950.00),
    (10, 10, 3, 1350.00);

-- Insert data into Payments with unique values and statuses
INSERT INTO Payments (BookingId, PaymentAmount, Status)
VALUES 
    (1, 1200.00, 'Completed'),
    (2, 800.00, 'Pending'),
    (3, 1500.00, 'Completed'),
    (4, 700.00, 'Pending'),
    (5, 600.00, 'Completed'),
    (6, 1600.00, 'Completed'),
    (7, 900.00, 'Pending'),
    (8, 550.00, 'Completed'),
    (9, 950.00, 'Completed'),
    (10, 1350.00, 'Pending');
