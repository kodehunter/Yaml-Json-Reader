# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields
ANS:
SELECT * from users WHERE id IN(3,2,4)

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium
ANS:
select count(L.id) as Premium, (select count(L.id) from listings L INNER JOIN users U ON U.id=L.user_id where U.status!=1 and L.status=2) as Basic from listings L INNER JOIN users U ON U.id=L.user_id where U.status!=1 and L.status=3

3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium


4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue
Ans:
Select U.first_name, U.last_name, C.currency, sum(C.price) as Revenue from clicks C, users U, listings L WHERE C.listing_id=L.user_id and L.user_id=U.id and Year(C.created)=2013 GROUP by U.first_name,U.last_name,C.currency

5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id
ANS:
INSERT INTO clicks VALUES (33,3,4.00,'USD', CURDATE());
select Max(ID) as ID FROM clicks


6. Show listings that have not received a click in 2013
- Please return at least: listing_name
ANS:
SELECT L.name from listings L INNER JOIN clicks C ON L.id=C.listing_id where Year(C.created)=2013 GROUP by L.name HAVING sum(C.price)=0


7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected
ANS:
Select Year(C.created) as Date, COUNT(C.id) as total_listings_clicked, COUNT(DISTINCT C.listing_id) as total_vendors_affected from listings L, clicks C, users U where L.id=C.listing_id and L.user_id=U.id GROUP BY Year(C.created)

8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names
ANS:
SELECT U.first_name, U.last_name, GROUP_CONCAT(name) as Names FROM listings L, users U where L.user_id=U.id and U.status!=1 GROUP by U.first_name, U.last_name