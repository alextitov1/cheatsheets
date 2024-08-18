# Analyze VPC Flow Logs Data in Athena
## Create the Athena Table

On the right, click Launch query editor.

Select the Settings tab and then click Manage.

In the Location of query result field, paste your copied S3 URI.

Click Save.

## Create Partitions and Analyze the Data

Select the query editor's Editor tab.

In the Query 1 editor, paste the following query, replacing {your_log_bucket} and {account_id} with your log bucket and account ID details (you can pull these from the S3 URI path you copied):

```
CREATE EXTERNAL TABLE IF NOT EXISTS default.vpc_flow_logs (
    version int,
    account string,
    interfaceid string,
    sourceaddress string,
    destinationaddress string,
    sourceport int,
    destinationport int,
    protocol int,
    numpackets int,
    numbytes bigint,
    starttime int,
    endtime int,
    action string,
    logstatus string
)
PARTITIONED BY (dt string)
ROW FORMAT DELIMITED
FIELDS TERMINATED BY ' '
LOCATION 's3://{your_log_bucket}/AWSLogs/{account_id}/vpcflowlogs/us-east-1/'
TBLPROPERTIES ("skip.header.line.count"="1");
```
Click Run.

You should see a message indicating that the query was successful.

On the right, click the + icon to open a new query editor.

In the editor, paste the following query, replacing YYYY-MM-DD with the current date, and replacing the existing location with your copied S3 URI:

```
ALTER TABLE default.vpc_flow_logs
    ADD PARTITION (dt='YYYY-MM-DD')
    location 's3://{your_log_bucket}/AWSLogs/{account_id}/vpcflowlogs/us-east-1/YYYY/MM/DD/';
```
Click Run.

You should see a message indicating that the query was successful.

On the right, click the + icon to open a new query editor.

In the editor, paste the following query:

```
SELECT day_of_week(from_iso8601_timestamp(dt)) AS
        day,
        dt,
        interfaceid,
        sourceaddress,
        destinationport,
        action,
        protocol
    FROM vpc_flow_logs
    WHERE action = 'REJECT' AND protocol = 6
    order by sourceaddress
    LIMIT 100;
```

Click Run.

Your partitioned data should display in the query results.

Conclusion