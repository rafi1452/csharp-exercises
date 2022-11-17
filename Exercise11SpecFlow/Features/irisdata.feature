Feature:irisdata
#species,property,type,result
@DataSource:irisR.csv
Scenario: Calculate statistics
    Given species is <species>
    Given property is <property>
    When we require the <type>
    Then the result should be <result>