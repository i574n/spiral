program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Double;
  v1: Double;
  v2: Double;
  v3: Double;
  v4: Double;
  v5: Double;
  v6: Single;
  v7: Double;
  v8: Boolean;
  v9: Double;
  v10: Boolean;
  v11: Double;
  v12: Double;
  v13: Boolean;
  v23: Double;
  v14: Double;
  v15: Boolean;
  v16: Double;
  v17: Double;
  v18: Double;
  v19: Boolean;
  v20: Double;
  v24: Boolean;
  v25: Double;
  v26: Double;
  v27: Boolean;
  v37: Double;
  v28: Double;
  v29: Boolean;
  v30: Double;
  v31: Double;
  v32: Double;
  v33: Boolean;
  v34: Double;
  v38: Boolean;
  v39: Double;
  v40: Double;
  v41: Boolean;
  v51: Double;
  v42: Double;
  v43: Boolean;
  v44: Double;
  v45: Double;
  v46: Double;
  v47: Boolean;
  v48: Double;
  v52: Boolean;
  v53: Double;
  v54: Double;
  v55: Boolean;
  v65: Double;
  v56: Double;
  v57: Boolean;
  v58: Double;
  v59: Double;
  v60: Double;
  v61: Boolean;
  v62: Double;
  v66: Boolean;
  v67: Double;
  v68: Double;
  v69: Boolean;
  v79: Double;
  v70: Double;
  v71: Boolean;
  v72: Double;
  v73: Double;
  v74: Double;
  v75: Boolean;
  v76: Double;
  v80: Boolean;
  v81: Double;
  v82: Double;
  v83: Double;
  v84: Boolean;
  v85: Single;
  v86: Boolean;
begin
  v0 := 2.7;
  v1 := 3.2;
  v2 := (-2.5);
  v3 := 3.5;
  v4 := 0.5;
  v5 := 1.0;
  v6 := 2.7;
  v7 := Int(v0) - Ord(Frac(v0) < 0);
  v8 := v7 <> 2.0;
  if v8 then begin
      Result := 1;
  end else begin
      v9 := Int(v0) + Ord(Frac(v0) > 0);
      v10 := v9 <> 3.0;
      if v10 then begin
          Result := 2;
      end else begin
          v11 := Int(v0) - Ord(Frac(v0) < 0);
          v12 := v0 - v11;
          v13 := v12 > 0.5;
          if v13 then begin
              v14 := v11 + 1.0;
              v23 := v14;
          end else begin
              v15 := v12 < 0.5;
              if v15 then begin
                  v23 := v11;
              end else begin
                  v16 := v11 / 2.0;
                  v17 := Int(v16) - Ord(Frac(v16) < 0);
                  v18 := v17 * 2.0;
                  v19 := v18 = v11;
                  if v19 then begin
                      v23 := v11;
                  end else begin
                      v20 := v11 + 1.0;
                      v23 := v20;
                  end;
              end;
          end;
          v24 := v23 <> 3.0;
          if v24 then begin
              Result := 3;
          end else begin
              v25 := Int(v1) - Ord(Frac(v1) < 0);
              v26 := v1 - v25;
              v27 := v26 > 0.5;
              if v27 then begin
                  v28 := v25 + 1.0;
                  v37 := v28;
              end else begin
                  v29 := v26 < 0.5;
                  if v29 then begin
                      v37 := v25;
                  end else begin
                      v30 := v25 / 2.0;
                      v31 := Int(v30) - Ord(Frac(v30) < 0);
                      v32 := v31 * 2.0;
                      v33 := v32 = v25;
                      if v33 then begin
                          v37 := v25;
                      end else begin
                          v34 := v25 + 1.0;
                          v37 := v34;
                      end;
                  end;
              end;
              v38 := v37 <> 3.0;
              if v38 then begin
                  Result := 4;
              end else begin
                  v39 := Int(v2) - Ord(Frac(v2) < 0);
                  v40 := v2 - v39;
                  v41 := v40 > 0.5;
                  if v41 then begin
                      v42 := v39 + 1.0;
                      v51 := v42;
                  end else begin
                      v43 := v40 < 0.5;
                      if v43 then begin
                          v51 := v39;
                      end else begin
                          v44 := v39 / 2.0;
                          v45 := Int(v44) - Ord(Frac(v44) < 0);
                          v46 := v45 * 2.0;
                          v47 := v46 = v39;
                          if v47 then begin
                              v51 := v39;
                          end else begin
                              v48 := v39 + 1.0;
                              v51 := v48;
                          end;
                      end;
                  end;
                  v52 := v51 <> (-2.0);
                  if v52 then begin
                      Result := 5;
                  end else begin
                      v53 := Int(v3) - Ord(Frac(v3) < 0);
                      v54 := v3 - v53;
                      v55 := v54 > 0.5;
                      if v55 then begin
                          v56 := v53 + 1.0;
                          v65 := v56;
                      end else begin
                          v57 := v54 < 0.5;
                          if v57 then begin
                              v65 := v53;
                          end else begin
                              v58 := v53 / 2.0;
                              v59 := Int(v58) - Ord(Frac(v58) < 0);
                              v60 := v59 * 2.0;
                              v61 := v60 = v53;
                              if v61 then begin
                                  v65 := v53;
                              end else begin
                                  v62 := v53 + 1.0;
                                  v65 := v62;
                              end;
                          end;
                      end;
                      v66 := v65 <> 4.0;
                      if v66 then begin
                          Result := 6;
                      end else begin
                          v67 := Int(v4) - Ord(Frac(v4) < 0);
                          v68 := v4 - v67;
                          v69 := v68 > 0.5;
                          if v69 then begin
                              v70 := v67 + 1.0;
                              v79 := v70;
                          end else begin
                              v71 := v68 < 0.5;
                              if v71 then begin
                                  v79 := v67;
                              end else begin
                                  v72 := v67 / 2.0;
                                  v73 := Int(v72) - Ord(Frac(v72) < 0);
                                  v74 := v73 * 2.0;
                                  v75 := v74 = v67;
                                  if v75 then begin
                                      v79 := v67;
                                  end else begin
                                      v76 := v67 + 1.0;
                                      v79 := v76;
                                  end;
                              end;
                          end;
                          v80 := v79 <> 0.0;
                          if v80 then begin
                              Result := 7;
                          end else begin
                              v81 := ArcTan2(v5, v5);
                              v82 := v81 * 1000.0;
                              v83 := Int(v82) - Ord(Frac(v82) < 0);
                              v84 := v83 <> 785.0;
                              if v84 then begin
                                  Result := 8;
                              end else begin
                                  v85 := Int(v6) - Ord(Frac(v6) < 0);
                                  v86 := v85 <> 2.0;
                                  if v86 then begin
                                      Result := 9;
                                  end else begin
                                      Result := 0;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
