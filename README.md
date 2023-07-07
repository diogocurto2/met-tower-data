# Met Tower Data

## Code Challenge
### Requirements
1) Meteorological (met) towers are used to collect onsite data for resource assessment. Anemometers and wind vanes are installed on the tower at various heights and boom orientations. Ten-minute data is collected for each sensor including the minimum, maximum,  average, and standard deviation over the ten-minute interval. Provide a proposed C#  class/struct architecture design that would hold all metadata and data for wind speed and wind direction sensors on a met tower. 
2) Using your class/struct design, write a function in C# that calculates and returns the average wind speed over a specified time period.  
3) Using your class/struct design, write a function in C# that calculates and returns the average wind shear power law exponent.
### Solution
The solution is on MetTowerData.sln

## Data Base Challenge
### Requirements
4) MySQL databases are used to store met tower data among other datasets at ArcVera. Present a  proposed MySQL database table structure that would hold the met tower metadata and data that are used in the above C# code. 
### Solution
the solution is on Mysql Creates.txt and MySql/MetTower.mwb (Mysql workbench) model.

## AWS 
### Question
AWS has several useful tools that are used in ArcVera’s software. In your own words, explain
what the following AWS tools are used for and provide an example of when each could be used:
a. SQS
b. SNS
c. SES
### Answer
a. SQS is a message queuing service. It allows you to decouple and scale microservices, distributed systems, and serverless applications. SQS enables asynchronous communication between components by providing a reliable and highly available message queue.
b. SNS is a publish-subscribe messaging service. It enables you to send messages or notifications to multiple subscribers (endpoints) simultaneously. Subscribers can receive messages, e.g. email, SMS, HTTP/HTTPS.
c. SES is a service for sending and receiving emails. It allows you to send transactional emails, marketing campaigns, and other types of high-quality content to your customers.

## PHP Challenge
### Question
6) PHP is used to define the API endpoints of ArcVera’s system. The following is an example snippet
of code used to GET database entries. However, there are two errors in the code. Identify and fix the bugs:
function handle_get($user, $contents, $path, $id) {
  $db = $user['db'];
  /* Following line ensures SQL errors propagate to the error log */
  $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
  $query = "SELECT * from {$user["customer_database"]}.{$GLOBALS['database_table']}";
  $args = [];
  $headers = apache_request_headers();
  if (!empty($id)) {
    $query = " WHERE ID = ?";
    $args[] = $id;
  } else if (isset($headers['station_id'])) {
    // Need this for the web map
    $stations = explode(",",$headers['station_id']);
    $impstn = [];
    foreach ($stations as $s) {
      $args[] = $s;
      $impstn[] = "?";
    }
    $query .= " where station_id IN (" . implode(",",$impstn) . ")";
  }
  $result = $db->prepare($stations);
  $result->execute($args);
  return ["station_lt_wind_ests"=>$result->fetchall(PDO::FETCH_ASSOC)];
}
### Solution
1. The line $query = " WHERE ID = ?"; is updated to $query .= " WHERE ID = ?"; to append the condition to the existing query string.
2. The line $result = $db->prepare($stations); is updated to $result = $db->prepare($query); to prepare the correct query string.
