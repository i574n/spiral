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
  v9: Boolean;
  v10: Double;
  v11: Boolean;
  v12: Boolean;
  v13: Double;
  v14: Double;
  v15: Boolean;
  v25: Double;
  v16: Double;
  v17: Boolean;
  v18: Double;
  v19: Double;
  v20: Double;
  v21: Boolean;
  v22: Double;
  v26: Boolean;
  v27: Boolean;
  v28: Double;
  v29: Double;
  v30: Boolean;
  v40: Double;
  v31: Double;
  v32: Boolean;
  v33: Double;
  v34: Double;
  v35: Double;
  v36: Boolean;
  v37: Double;
  v41: Boolean;
  v42: Boolean;
  v43: Double;
  v44: Double;
  v45: Boolean;
  v55: Double;
  v46: Double;
  v47: Boolean;
  v48: Double;
  v49: Double;
  v50: Double;
  v51: Boolean;
  v52: Double;
  v56: Boolean;
  v57: Boolean;
  v58: Double;
  v59: Double;
  v60: Boolean;
  v70: Double;
  v61: Double;
  v62: Boolean;
  v63: Double;
  v64: Double;
  v65: Double;
  v66: Boolean;
  v67: Double;
  v71: Boolean;
  v72: Boolean;
  v73: Double;
  v74: Double;
  v75: Boolean;
  v85: Double;
  v76: Double;
  v77: Boolean;
  v78: Double;
  v79: Double;
  v80: Double;
  v81: Boolean;
  v82: Double;
  v86: Boolean;
  v87: Boolean;
  v88: Double;
  v89: Double;
  v90: Double;
  v91: Boolean;
  v92: Boolean;
  v93: Single;
  v94: Boolean;
  v95: Boolean;
begin
  v0 := 2.7;
  v1 := 3.2;
  v2 := (-2.5);
  v3 := 3.5;
  v4 := 0.5;
  v5 := 1.0;
  v6 := 2.7;
  v7 := Int(v0) - Ord(Frac(v0) < 0);
  v8 := v7 = 2.0;
  v9 := v8 <> True;
  if v9 then begin
      Result := 1;
  end else begin
      v10 := Int(v0) + Ord(Frac(v0) > 0);
      v11 := v10 = 3.0;
      v12 := v11 <> True;
      if v12 then begin
          Result := 2;
      end else begin
          v13 := Int(v0) - Ord(Frac(v0) < 0);
          v14 := v0 - v13;
          v15 := v14 > 0.5;
          if v15 then begin
              v16 := v13 + 1.0;
              v25 := v16;
          end else begin
              v17 := v14 < 0.5;
              if v17 then begin
                  v25 := v13;
              end else begin
                  v18 := v13 / 2.0;
                  v19 := Int(v18) - Ord(Frac(v18) < 0);
                  v20 := v19 * 2.0;
                  v21 := v20 = v13;
                  if v21 then begin
                      v25 := v13;
                  end else begin
                      v22 := v13 + 1.0;
                      v25 := v22;
                  end;
              end;
          end;
          v26 := v25 = 3.0;
          v27 := v26 <> True;
          if v27 then begin
              Result := 3;
          end else begin
              v28 := Int(v1) - Ord(Frac(v1) < 0);
              v29 := v1 - v28;
              v30 := v29 > 0.5;
              if v30 then begin
                  v31 := v28 + 1.0;
                  v40 := v31;
              end else begin
                  v32 := v29 < 0.5;
                  if v32 then begin
                      v40 := v28;
                  end else begin
                      v33 := v28 / 2.0;
                      v34 := Int(v33) - Ord(Frac(v33) < 0);
                      v35 := v34 * 2.0;
                      v36 := v35 = v28;
                      if v36 then begin
                          v40 := v28;
                      end else begin
                          v37 := v28 + 1.0;
                          v40 := v37;
                      end;
                  end;
              end;
              v41 := v40 = 3.0;
              v42 := v41 <> True;
              if v42 then begin
                  Result := 4;
              end else begin
                  v43 := Int(v2) - Ord(Frac(v2) < 0);
                  v44 := v2 - v43;
                  v45 := v44 > 0.5;
                  if v45 then begin
                      v46 := v43 + 1.0;
                      v55 := v46;
                  end else begin
                      v47 := v44 < 0.5;
                      if v47 then begin
                          v55 := v43;
                      end else begin
                          v48 := v43 / 2.0;
                          v49 := Int(v48) - Ord(Frac(v48) < 0);
                          v50 := v49 * 2.0;
                          v51 := v50 = v43;
                          if v51 then begin
                              v55 := v43;
                          end else begin
                              v52 := v43 + 1.0;
                              v55 := v52;
                          end;
                      end;
                  end;
                  v56 := v55 = (-2.0);
                  v57 := v56 <> True;
                  if v57 then begin
                      Result := 5;
                  end else begin
                      v58 := Int(v3) - Ord(Frac(v3) < 0);
                      v59 := v3 - v58;
                      v60 := v59 > 0.5;
                      if v60 then begin
                          v61 := v58 + 1.0;
                          v70 := v61;
                      end else begin
                          v62 := v59 < 0.5;
                          if v62 then begin
                              v70 := v58;
                          end else begin
                              v63 := v58 / 2.0;
                              v64 := Int(v63) - Ord(Frac(v63) < 0);
                              v65 := v64 * 2.0;
                              v66 := v65 = v58;
                              if v66 then begin
                                  v70 := v58;
                              end else begin
                                  v67 := v58 + 1.0;
                                  v70 := v67;
                              end;
                          end;
                      end;
                      v71 := v70 = 4.0;
                      v72 := v71 <> True;
                      if v72 then begin
                          Result := 6;
                      end else begin
                          v73 := Int(v4) - Ord(Frac(v4) < 0);
                          v74 := v4 - v73;
                          v75 := v74 > 0.5;
                          if v75 then begin
                              v76 := v73 + 1.0;
                              v85 := v76;
                          end else begin
                              v77 := v74 < 0.5;
                              if v77 then begin
                                  v85 := v73;
                              end else begin
                                  v78 := v73 / 2.0;
                                  v79 := Int(v78) - Ord(Frac(v78) < 0);
                                  v80 := v79 * 2.0;
                                  v81 := v80 = v73;
                                  if v81 then begin
                                      v85 := v73;
                                  end else begin
                                      v82 := v73 + 1.0;
                                      v85 := v82;
                                  end;
                              end;
                          end;
                          v86 := v85 = 0.0;
                          v87 := v86 <> True;
                          if v87 then begin
                              Result := 7;
                          end else begin
                              v88 := ArcTan2(v5, v5);
                              v89 := v88 * 1000.0;
                              v90 := Int(v89) - Ord(Frac(v89) < 0);
                              v91 := v90 = 785.0;
                              v92 := v91 <> True;
                              if v92 then begin
                                  Result := 8;
                              end else begin
                                  v93 := Int(v6) - Ord(Frac(v6) < 0);
                                  v94 := v93 = 2.0;
                                  v95 := v94 <> True;
                                  if v95 then begin
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
