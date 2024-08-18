# CloudWatch

## Create a CloudWatch Log Metric Filter

Select the Metric filters tab and then click Create metric filter.

In the Filter pattern field, enter the following pattern to track failed SSH attempts on port 22:

```
[version, account, eni, source, destination, srcport, destport="22", protocol="6", packets, bytes, windowstart, windowend, action="REJECT", flowlogstatus]
```
Use the Select log data to test dropdown to select Custom log data.

In the Log event messages field, replace the existing log data with the following:
```
2 086112738802 eni-0d5d75b41f9befe9e 61.177.172.128 172.31.83.158 39611 22 6 1 40 1563108188 1563108227 REJECT OK
2 086112738802 eni-0d5d75b41f9befe9e 182.68.238.8 172.31.83.158 42227 22 6 1 44 1563109030 1563109067 REJECT OK
2 086112738802 eni-0d5d75b41f9befe9e 42.171.23.181 172.31.83.158 52417 22 6 24 4065 1563191069 1563191121 ACCEPT OK
2 086112738802 eni-0d5d75b41f9befe9e 61.177.172.128 172.31.83.158 39611 80 6 1 40 1563108188 1563108227 REJECT OK
```

Click Test pattern and then review the results.

Click Next.

Fill in the metric details:
```
Filter name: In the text field, enter dest-port-22-reject.
Metric namespace: In the text field, enter a name (e.g., vpcflowlogs).
Metric name: In the text field, enter SSH Rejects.
Metric value: In the text field, enter 1.
```
Leave the other fields blank and click Next.

Review the metric details and then click `Create metric filter`.


# Use CloudWatch Logs Insights

In the CloudWatch sidebar menu, navigate to Logs and select Logs Insights.

Use the Select log group(s) search bar to select VPCFlowLogs.

In the right-hand pane, select Queries.

In the Sample queries section, expand VPC Flow Logs and then expand Top 20 source IP addresses with highest number of rejected requests.

Click Apply and note the changes applied in the query editor.

Click Run query.

After a few moments, you'll see some data start to populate.