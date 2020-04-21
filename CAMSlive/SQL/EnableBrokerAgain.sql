use CAMSlive

alter database camslive set single_user with rollback immediate
alter database camslive set enable_broker
alter database camslive set multi_user with rollback immediate
