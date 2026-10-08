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
  v21: Double;
  v22: Boolean;
  v23: Boolean;
  v39: Double;
  v40: Boolean;
  v41: Boolean;
  v156: Double;
  v157: Double;
  v158: Boolean;
  v168: Double;
  v159: Double;
  v160: Boolean;
  v161: Double;
  v162: Double;
  v163: Double;
  v164: Boolean;
  v165: Double;
  v169: Boolean;
  v170: Boolean;
  v171: Double;
  v172: Double;
  v173: Boolean;
  v183: Double;
  v174: Double;
  v175: Boolean;
  v176: Double;
  v177: Double;
  v178: Double;
  v179: Boolean;
  v180: Double;
  v184: Boolean;
  v185: Boolean;
  v186: Double;
  v187: Double;
  v188: Boolean;
  v198: Double;
  v189: Double;
  v190: Boolean;
  v191: Double;
  v192: Double;
  v193: Double;
  v194: Boolean;
  v195: Double;
  v199: Boolean;
  v200: Boolean;
  v201: Double;
  v202: Double;
  v203: Boolean;
  v213: Double;
  v204: Double;
  v205: Boolean;
  v206: Double;
  v207: Double;
  v208: Double;
  v209: Boolean;
  v210: Double;
  v214: Boolean;
  v215: Boolean;
  v216: Double;
  v217: Double;
  v218: Boolean;
  v228: Double;
  v219: Double;
  v220: Boolean;
  v221: Double;
  v222: Double;
  v223: Double;
  v224: Boolean;
  v225: Double;
  v229: Boolean;
  v230: Boolean;
  v242: Double;
  v243: Double;
  v244: Double;
  v245: Boolean;
  v246: Boolean;
  v261: Single;
  v262: Boolean;
  v263: Boolean;
begin
  v0 := 2.7;
  v1 := 3.2;
  v2 := (-2.5);
  v3 := 3.5;
  v4 := 0.5;
  v5 := 1.0;
  v6 := 2.7;
  v21 := Int(v0) - Ord(Frac(v0) < 0);
  v22 := v21 = 2.0;
  v23 := v22 <> True;
  if v23 then begin
      Result := 1;
  end else begin
      v39 := Int(v0) + Ord(Frac(v0) > 0);
      v40 := v39 = 3.0;
      v41 := v40 <> True;
      if v41 then begin
          Result := 2;
      end else begin
          v156 := Int(v0) - Ord(Frac(v0) < 0);
          v157 := v0 - v156;
          v158 := v157 > 0.5;
          if v158 then begin
              v159 := v156 + 1.0;
              v168 := v159;
          end else begin
              v160 := v157 < 0.5;
              if v160 then begin
                  v168 := v156;
              end else begin
                  v161 := v156 / 2.0;
                  v162 := Int(v161) - Ord(Frac(v161) < 0);
                  v163 := v162 * 2.0;
                  v164 := v163 = v156;
                  if v164 then begin
                      v168 := v156;
                  end else begin
                      v165 := v156 + 1.0;
                      v168 := v165;
                  end;
              end;
          end;
          v169 := v168 = 3.0;
          v170 := v169 <> True;
          if v170 then begin
              Result := 3;
          end else begin
              v171 := Int(v1) - Ord(Frac(v1) < 0);
              v172 := v1 - v171;
              v173 := v172 > 0.5;
              if v173 then begin
                  v174 := v171 + 1.0;
                  v183 := v174;
              end else begin
                  v175 := v172 < 0.5;
                  if v175 then begin
                      v183 := v171;
                  end else begin
                      v176 := v171 / 2.0;
                      v177 := Int(v176) - Ord(Frac(v176) < 0);
                      v178 := v177 * 2.0;
                      v179 := v178 = v171;
                      if v179 then begin
                          v183 := v171;
                      end else begin
                          v180 := v171 + 1.0;
                          v183 := v180;
                      end;
                  end;
              end;
              v184 := v183 = 3.0;
              v185 := v184 <> True;
              if v185 then begin
                  Result := 4;
              end else begin
                  v186 := Int(v2) - Ord(Frac(v2) < 0);
                  v187 := v2 - v186;
                  v188 := v187 > 0.5;
                  if v188 then begin
                      v189 := v186 + 1.0;
                      v198 := v189;
                  end else begin
                      v190 := v187 < 0.5;
                      if v190 then begin
                          v198 := v186;
                      end else begin
                          v191 := v186 / 2.0;
                          v192 := Int(v191) - Ord(Frac(v191) < 0);
                          v193 := v192 * 2.0;
                          v194 := v193 = v186;
                          if v194 then begin
                              v198 := v186;
                          end else begin
                              v195 := v186 + 1.0;
                              v198 := v195;
                          end;
                      end;
                  end;
                  v199 := v198 = (-2.0);
                  v200 := v199 <> True;
                  if v200 then begin
                      Result := 5;
                  end else begin
                      v201 := Int(v3) - Ord(Frac(v3) < 0);
                      v202 := v3 - v201;
                      v203 := v202 > 0.5;
                      if v203 then begin
                          v204 := v201 + 1.0;
                          v213 := v204;
                      end else begin
                          v205 := v202 < 0.5;
                          if v205 then begin
                              v213 := v201;
                          end else begin
                              v206 := v201 / 2.0;
                              v207 := Int(v206) - Ord(Frac(v206) < 0);
                              v208 := v207 * 2.0;
                              v209 := v208 = v201;
                              if v209 then begin
                                  v213 := v201;
                              end else begin
                                  v210 := v201 + 1.0;
                                  v213 := v210;
                              end;
                          end;
                      end;
                      v214 := v213 = 4.0;
                      v215 := v214 <> True;
                      if v215 then begin
                          Result := 6;
                      end else begin
                          v216 := Int(v4) - Ord(Frac(v4) < 0);
                          v217 := v4 - v216;
                          v218 := v217 > 0.5;
                          if v218 then begin
                              v219 := v216 + 1.0;
                              v228 := v219;
                          end else begin
                              v220 := v217 < 0.5;
                              if v220 then begin
                                  v228 := v216;
                              end else begin
                                  v221 := v216 / 2.0;
                                  v222 := Int(v221) - Ord(Frac(v221) < 0);
                                  v223 := v222 * 2.0;
                                  v224 := v223 = v216;
                                  if v224 then begin
                                      v228 := v216;
                                  end else begin
                                      v225 := v216 + 1.0;
                                      v228 := v225;
                                  end;
                              end;
                          end;
                          v229 := v228 = 0.0;
                          v230 := v229 <> True;
                          if v230 then begin
                              Result := 7;
                          end else begin
                              v242 := ArcTan2(v5, v5);
                              v243 := v242 * 1000.0;
                              v244 := Int(v243) - Ord(Frac(v243) < 0);
                              v245 := v244 = 785.0;
                              v246 := v245 <> True;
                              if v246 then begin
                                  Result := 8;
                              end else begin
                                  v261 := Int(v6) - Ord(Frac(v6) < 0);
                                  v262 := v261 = 2.0;
                                  v263 := v262 <> True;
                                  if v263 then begin
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
