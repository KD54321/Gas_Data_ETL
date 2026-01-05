CREATE TABLE operationally_available_capacity (
  id SERIAL PRIMARY KEY,
  gas_day DATE NOT NULL,
  gas_cycle INT NOT NULL,
  created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
  
  loc TEXT NOT NULL,
  loc_zn TEXT NOT NULL,
  loc_name TEXT NOT NULL,
  loc_purp_desc TEXT NOT NULL,
  loc_qti TEXT NOT NULL,
  flow_ind CHAR(1) NOT NULL,
  dc NUMERIC,
  opc NUMERIC,
  tsq NUMERIC,
  oac NUMERIC,
  it CHAR(1),
  auth_overrun_ind CHAR(1),
  nom_cap_exceed_ind CHAR(1),
  all_qty_avail CHAR(1),
  qty_reason TEXT
);