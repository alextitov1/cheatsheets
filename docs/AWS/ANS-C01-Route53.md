# Route 53

## CNAME vs AWS Alias

* CNAME
  * DNS record type
  * Referred to as an "alias"
  * Redirects to other DNS record names
  * **Returns FQDN to client**
  * Charge per-query
  * Name cannot be re-used in zone
  * Not used to represent zone apex(top)
  
* Alias
  * Not a DNS record type
  * AWS Route 53 extension
  * Redirects to AWS service object FQDNs
  * **Returns IP address to client**
  * No query charges
  * Can re-use name
  * Can be used to represent zone apex