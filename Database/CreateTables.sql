DROP TABLE IEP_USER.POC_CNTRY CASCADE CONSTRAINTS;

CREATE TABLE IEP_USER.POC_CNTRY
(
  CNTRY_ID  NUMBER                              NOT NULL,
  CLNCL_ID  VARCHAR2(50 CHAR)
)
TABLESPACE IEP_DATA_T01
RESULT_CACHE (MODE DEFAULT)
PCTUSED    0
PCTFREE    10
INITRANS   1
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            NEXT             1M
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
            FLASH_CACHE      DEFAULT
            CELL_FLASH_CACHE DEFAULT
           )
LOGGING 
NOCOMPRESS 
NOCACHE
NOPARALLEL
MONITORING;

DROP TABLE IEP_USER.POC_SUBJECT CASCADE CONSTRAINTS;

CREATE TABLE IEP_USER.POC_SUBJECT
(
  SITE_ID          NUMBER                       NOT NULL,
  CLNCL_ID         VARCHAR2(50 CHAR)            NOT NULL,
  CNTRY_ID         NUMBER                       NOT NULL,
  SUBJ_ENTR_SCRNG  NUMBER
)
TABLESPACE IEP_DATA_T01
RESULT_CACHE (MODE DEFAULT)
PCTUSED    0
PCTFREE    10
INITRANS   1
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            NEXT             1M
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
            FLASH_CACHE      DEFAULT
            CELL_FLASH_CACHE DEFAULT
           )
LOGGING 
NOCOMPRESS 
NOCACHE
NOPARALLEL
MONITORING;
