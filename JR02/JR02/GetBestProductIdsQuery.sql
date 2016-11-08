select ProductId, count(CustomerId)
from
(
   select ProductId, CustomerId, 
             ROW_NUMBER() over(partition by CustomerId order by DateCreated) rowNum
   from Sales
) z
where rowNum = 1
group by z.ProductId
